# Managed Identities and secrets in .NET and Azure

These are three sample apps to demo managed identities for Azure resources​ and best practices for secrets management.

- **WebServiceManagedIdentity**

  Web service uses Managed Identity to connect to the blob storage.

- **WebServiceKeyVault**

  Web Service connects to the Key Vault to obtain connection string to the blob storage.
  User Secrets are used for local development.

- **WebServiceUnsafe**
  Web Service uses unsafe practices to obtain a connection string e. g. injecting into the config file or setting environmental variables.
