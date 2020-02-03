## Instructions

Note that Docker Desktop must be installed and running (Kubernetes support must also be enabled) or another Kubernetes option such as Minikube can be used.

1. `cd` into the root of this folder in a command window
1. Run `docker-compose build` to build the images that will be used for Blue-Green testing
1. Run the following commands based on your OS

    ### Mac/Linux

    Define environment variables for green

    `export TARGET_ROLE=blue`

    `export IMAGE_VERSION=nginx-blue`

    Run a script to apply the environment variables to the deployment files

    `cat nginx.deployment.yml | sh config.sh | kubectl create --save-config -f -`

    `cat nginx.service.yml | sh config.sh | kubectl create --save-config -f -`
    
    `kubectl create -f nginx-blue-test.service.yml`

    ### Windows

    Define environment variables for green

    `$Env:TARGET_ROLE="blue"`

    `$Env:IMAGE_VERSION="nginx-blue"`

    Run a script to apply the environment variables to the deployment files

    `cat nginx.deployment.yml | ./config.ps1 | kubectl create --save-config -f -`

    `cat nginx.service.yml | ./config.ps1 | kubectl create --save-config -f -`

    `kubectl create -f nginx-blue-test.service.yml`

### Switch to Green Deployment

1. Set the environment variables shown earlier (commands are shown above) to `green` and `nginx-green` respectively. 
1. Run the Deployment command again to get the green Deployment running:

    ### Mac/Linux

    `cat nginx.deployment.yml | sh config.sh | kubectl create --save-config -f -`

    ### Windows

    `cat nginx.deployment.yml | ./config.ps1 | kubectl create --save-config -f -`

1. Create the green test Service:

    `kubectl create -f nginx-green-test.service.yml --save-config`

1. Visit `http://localhost:9001` to ensure the green app is working correctly. 
1. If it is working properly, run the following command to switch the "public" service to the green Deployment:

    **Mac/Linux**

    `cat nginx.service.yml | sh config.sh | kubectl apply -f -`

    **Windows**

    `cat nginx.service.yml | ./config.ps1 | kubectl apply -f -`

1. Visit `http://localhost` and notice that the green Deployment is now being hit using the "public" service.

1. Delete the blue test service and deployment once done.



