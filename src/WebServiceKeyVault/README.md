# WebServiceKeyVault

Web Service connects to the Key Vault to obtain connection string to the blob storage.
User Secrets are used for local development.

`BlobSettings--ConnectionString` should be added to the Key Vault and User Secrets.

`KeyVaultUri` should be configured so the app knows where to connect to.
The app authorizes to Key Vault using Managed Identity, certificate can be also used.