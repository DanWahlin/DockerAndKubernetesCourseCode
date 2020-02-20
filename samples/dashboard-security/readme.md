## Installing the Kubernetes Dashboard

- https://kubernetes.io/docs/tasks/access-application-cluster/web-ui-dashboard/#deploying-the-dashboard-ui
- https://github.com/kubernetes/dashboard/wiki/Creating-sample-user
- https://github.com/kubernetes/dashboard

#### Step to use:
1. Install the Kubernetes Dashboard:

    `kubectl apply -f https://raw.githubusercontent.com/kubernetes/dashboard/v2.0.0-beta8/aio/deploy/recommended.yaml`

2. Run `kubectl apply -f dashboard.adminuser.yml`
3. Get a token (see https://github.com/kubernetes/dashboard/wiki/Creating-sample-user) by running one of the following. Copy the token into your clipboard.

    Bash:

    `kubectl -n kubernetes-dashboard describe secret $(kubectl -n kubernetes-dashboard get secret | grep admin-user | awk '{print $1}')`

    Powershell:

    `kubectl -n kubernetes-dashboard describe secret $(kubectl -n kubernetes-dashboard get secret | sls admin-user | ForEach-Object { $_ -Split '\s+' } | Select -First 1)`

4. Run `kubectl proxy`.
5. Visit http://localhost:8001/api/v1/namespaces/kubernetes-dashboard/services/https:kubernetes-dashboard:/proxy/
6. Paste the token into the login screen and you can then sign in to the dashboard.