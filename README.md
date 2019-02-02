# Azure API Management Policies for Blob Upload

A pretty common requirement is to be able to upload files from a mobile app to Blob storage in Azure. There are multiple ways to achieve this using SAS Tokens. The first way is to call a service which generates a SAS token on the fly and then uploads the file into Blob Storage. The second way is to call a service which just generates a token and then the mobile app uses that token to upload directly to Blob Storage. In both cases Azure API management can be used as that service. This repository consists of sample policies which demonstrate how this can be achieved.

1. Upload Blob Directly using an API (upload.xml)
2. API Mgmt service to generate a SAS token (generateSAS.xml)