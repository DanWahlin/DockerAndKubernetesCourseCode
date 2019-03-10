## Installing the Kubernetes Dashboard

https://github.com/kubernetes/dashboard/wiki/Creating-sample-user

#### Step to use:
1. Install the Kubernetes Dashboard:

    `kubectl create -f https://raw.githubusercontent.com/kubernetes/dashboard/master/aio/deploy/recommended/kubernetes-dashboard.yaml`

2. Run `kubectl apply -f dashboard.adminuser.yml`
3. Get a token (see https://github.com/kubernetes/dashboard/wiki/Creating-sample-user)
4. Visit http://localhost:8001/api/v1/namespaces/kube-system/services/https:kubernetes-dashboard:/proxy/
5. Paste the token into the login screen and you can then sign in to the dashboard.