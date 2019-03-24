# Commands Used in the Lab

## Exercise 1
- az login
- az account list
- az account set -s <your-subscription-id>
- az account show

## Exercise 2

- az group create --name AKSLab-ResourceGroup --location westus
- az group list

## Exercise 3

- az ad sp create-for-rbac  --name AKSServicePrinciple --skip-assignment
- az acr create --name AKSLabACR<any-four-digit-number>  --resource-group AKSLab-ResourceGroup --location westus --sku standard
- az acr login --name <your-acr-name
- az acr list -o table
- az acr repository list -n <your-acr-name> -o table

    **Windows Powershell**

        $acrId=az acr show -n <your-acr-name> -g AKSLab-ResourceGroup --query "id" -o tsv

    **Mac/Linux**

        acrId=$(az acr show -n <your-acr-name> -g AKSLab-ResourceGroup --query "id" -o tsv)

- echo $acrId
- az role assignment create --assignee "<your-sp-appId>" --role Reader --scope $acrId

## Exercise 4

- az aks -h
- az aks create --resource-group AKSLab-ResourceGroup --name AKSLabCluster --node-count 1 --node-vm-size Standard_D2_v2 --service-principal "<your-sp-appId>" --client-secret "<your-sp-password>" --enable-addons monitoring --generate-ssh-keys
- az aks get-credentials -n AKSLabCluster -g AKSLab-ResourceGroup
- kubectl create clusterrolebinding kubernetes-dashboard --clusterrole=cluster-admin --serviceaccount=kube-system:kubernetes-dashboard
- az aks browse -g AKSLab-ResourceGroup -n AKSLabCluster
- az group delete -g AKSLab-ResourceGroup --yes --no-wait
- kubectl config delete-cluster AKSLabCluster
- kubectl config delete-context AKSLabCluster
- kubectl config get-contexts
- kubectl config use-context [local-context-name]
- kubectl get nodes











