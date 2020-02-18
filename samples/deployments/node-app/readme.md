## Running the Deployments

1. Run `docker-compose build` from the root of this directory to build the images. Alternatively you can build the `node-app` images using the dockerfiles in the v1, v2, v3 folders using `docker build`. If you do it manually with docker build make sure you tag the images with 1.0, 2.0, 3.0 (ex: node-app:1.0, node-app:2.0, etc.).
1. You can then run one of the k8s deployment yaml files using `kubectl apply -f node-app-v1.deployment.yml` (replace v1 with the appropriate version to run the other deployments).