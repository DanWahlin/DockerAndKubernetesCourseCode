## Rolling Update Deployment Instructions

1. Deploy the Deployment and Service by running the following command:

    `kubectl create -f ./ --save-config --record`

1. Run `kubectl get all` and notice that 4 Pods, 1 Deployment, and 1 ReplicaSet have successfully been deployed.
1. Open a separate command window and run one of the following scripts based on your OS to call into the nginx Pods:

    **Windows (open a PowerShell window):**

    `./curl-loop.ps1`

    **Mac**

    `sh curl-loop.sh`

1. Change the image version in `nginx.deployment.yml` to the one shown in the comment right next to it. Save the file.
1. Run the following command to apply the new Deployment:

    `kubectl apply -f nginx.deployment.yml --record`

1. Go back and check the curl commands being made by the script and you should see no interuption in the service. This demonstrates a Rolling Deployment in action.
1. Check the Deployment status by running the following:

    `kubectl rollout status deployment my-nginx`



