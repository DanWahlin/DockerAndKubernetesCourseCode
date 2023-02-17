## Installing the Kubernetes Dashboard

- https://kubernetes.io/docs/tasks/access-application-cluster/web-ui-dashboard/
- https://github.com/kubernetes/dashboard/blob/master/docs/user/access-control/creating-sample-user.md
- https://github.com/kubernetes/dashboard

#### Step to use:
1. Install the Kubernetes Dashboard:

    `kubectl apply -f https://raw.githubusercontent.com/kubernetes/dashboard/v2.7.0/aio/deploy/recommended.yaml`

2. Run `kubectl apply -f dashboard.adminuser.yml`
3. Get a token (see https://github.com/kubernetes/dashboard/wiki/Creating-sample-user) by running the following. Copy the token into your clipboard.

    `kubectl -n kubernetes-dashboard create token admin-user`

4. Run `kubectl proxy`.
5. Visit http://localhost:8001/api/v1/namespaces/kubernetes-dashboard/services/https:kubernetes-dashboard:/proxy/
6. Paste the token into the login screen and you can then sign in to the dashboard.