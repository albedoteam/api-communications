terraform {
  required_providers {
    kubernetes = {
      source  = "hashicorp/kubernetes"
      version = ">= 2.0.0"
    }
  }
}

provider "kubernetes" {
  config_path = "~/.kube/config"
}

resource "kubernetes_namespace" "communications" {
  metadata {
    name = "communications-api"
  }
}

resource "kubernetes_deployment" "communications" {
  metadata {
    name = "communications-api"
    namespace = kubernetes_namespace.communications.metadata.0.name
    labels = {
      app = "CommunicationsApi"
    }
  }

  spec {
    replicas = 2
    selector {
      match_labels = {
        app = "communications-api"
      }
    }
    template {
      metadata {
        labels = {
          app = "communications-api"
        }
      }
      spec {
        container {
          image = "communications-api:latest"
          name = "communications-api-container"
          image_pull_policy = "IfNotPresent"
          port {
            container_port = 80
            protocol = "TCP"
          }
          env {
            name = "ASPNETCORE_URLS"
            value = "http://+:80"
          }
        }
      }
    }
  }
}

resource "kubernetes_service" "communications" {
  metadata {
    name = "communications-api"
    namespace = kubernetes_namespace.communications.metadata.0.name
    labels = {
      app = "communications-api"
    }
  }
  spec {
    type = "LoadBalancer"
    port {
      port = "5200"
      target_port = "80"
      protocol = "TCP"
    }
    selector = {
      app = kubernetes_deployment.communications.spec.0.template.0.metadata.0.labels.app
    }
  }
}