## Instructions

This project can be used to display a simple console-based dashboard for Blue-Green Deployments and their associated services.

```
Deployment              Role   Status   Image        Ports     Services                      
----------------------  -----  -------  -----------  --------  ----------------
nginx-deployment-blue   blue   running  nginx-blue   80, 9000  nginx-blue-test, nginx-service
nginx-deployment-green  green  running  nginx-green  9001      nginx-green-test
```

1. Start the Blue-Green Deployments (see the README at the root of the `samples/blue-green` folder for information)
1. Run `npm install`
1. Run `npm run build`
1. Run `npm start`

Based on the https://github.com/kubernetes-client/javascript api.

