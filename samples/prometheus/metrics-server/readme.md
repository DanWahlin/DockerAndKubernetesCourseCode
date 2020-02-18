## Installing Metrics Server Into Kubernetes

https://github.com/kubernetes-incubator/metrics-server

1. To see if you already have Metrics Server installed run:

    `kubectl get svc -n kube-system`

    If you don't see any metrics-server info then it's not installed.

2. If Metrics Server isn't listed run the following command (from this directory):

    `kubectl create -f ./kubernetes`

3. Run the following command to get the metrics server Pod name:

    `kubectl get pods -n kube-system`

3. Run the following and make sure now errors are shown:

    `kubectl logs [metrics-server-pod-name] -n kube-system`


Note: The `metrics-server-deployment.yaml` file has been modified for Docker Desktop as mentioned here:

https://blog.codewithdan.com/enabling-metrics-server-for-kubernetes-on-docker-desktop