variable "src_name" {
  description = "Source name"
  type        = string
  default     = "communications-api"
}

variable "deployment_label" {
  description = "Deployment Label / Container Name"
  type        = string
  default     = "CommunicationsApi"
}

variable "secret_name" {
  description = "Secret name"
  type        = string
  default     = "communications-secrets"
}

variable "broker_connection_string" {
  description = "Broker Connection String"
  type        = string
  sensitive   = true
  default     = ""
}

variable "replicas_count" {
  description = "Number of container replicas to provision."
  type        = number
  default     = 1
}