## Instructions

Note that Docker Desktop must be installed and running (Kubernetes support must also be enabled) or another Kubernetes option such as Minikube can be used.

1. `cd` into the root of this folder in a command window
1. Run `docker-compose build` to build the images that will be used for Canary testing
1. Create the Kubernetes Service, Stable Deployment, and Canary Deployment by running the following command:

    `kubectl apply -f ./`

    Note: You'll get an error about `docker-compose.yml` but can ignore it (it's not a valid Kubernetes file of course).

1. Run the following command based on your OS:

    **Windows**

    Open a PowerShell window:

    `./curl-loop.ps1`

    **Mac**

    `sh curl-loop.sh`

1. Because the Stable Deployment has 4 replicas and the Canary Deployment only has 1, the output should show Stable app output most of the time. If you don't see Canary app show up at all run the command again.