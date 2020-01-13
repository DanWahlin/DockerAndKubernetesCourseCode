## Running the Deployments

1. Build the node-app images using the dockerfile in the v1, v2, v3 folders using `docker build`
1. Make sure you tag the images with 1.0, 2.0, 3.0
1. You can then run one of the k8s deployment yaml files using `kubectl apply -f node-app-v1.deployment.yml` (replace v1 with the appropriate version to run the other deployments).