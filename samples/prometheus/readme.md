## Prometheus, kube-state-metrics, Metrics Server, Grafana Example

1. Run `kubectl create namespace monitoring` to create a `monitoring` namespace.
1. Run `kubectl create -f ./ -R` to get kube-state-metrics, Grafana, and Prometheus resources in place.
1. Visit http://localhost:30000 to view Prometheus.
1. Click on Graph. Select a metric from the drop-down (next to the Execute button) and then click Execute. You can switch between the Graph view and Console view.
1. Visit http://localhost:32000 to view the Grafana dashboard.
1. Login with `admin` and `admin` for the username and password. You can reset the password on the next screen or click `Skip`.
1. On the `Welcome to Grafana` page click `New dashboard`.
1. Click the drop-down item named `Home` in the upper-left corner of the screen.
1. Select `Import dashboard` from the available options.
1. Enter an ID value of `10000` into the `Grafana.com Dashboard` textbox and click `Load`. This will load the `Cluster Monitoring for Kubernetes` dashboard.

    Note: You can find a list of pre-configured dashboards at https://grafana.com/grafana/dashboards. Each one will have an id you can copy into the Grafana `Import dashboard` screen.

1. On the next screen you'll see a `Select a Prometheus data source` drop-down. Select `prometheus` from the list and click `Import`. Your dashboard will now load.
1. Click on the `Cluster Monitoring for Kubernetes` drop-down in the uppper-left corner of the screen. Go back through the steps to import a dashboard but this time enter an ID of `8588`. This will load the `Kubernetes Deployment Statefulset Daemonset metrics` dashboard.
1. If you click on the dashboard name drop-down in the upper-left corner of the screen you'll see both of your dashboards listed and can now switch between them.
1. Import the dashboard with an ID of `10694`. This dashboard is called `Container Statistics`. 
1. From here you can load other dashboards or create your own!

**NOTE**: The Metrics Server YAML has been modified to enable it to run in more simple Kubernetes scenarios like Docker Desktop. Details about the modifications made can be found at https://blog.codewithdan.com/enabling-metrics-server-for-kubernetes-on-docker-desktop. You'll want to remove the `--kubelet-insecure-tls` arg in `metrics-server/kubernetes/metrics-server-deployment.yaml` for more real-world scenarios.

## Removing Resources

To remove all of the monitoring resources run `kubectl delete -f ./ -R`.

## Additional Details

Get more details on Prometheus at https://prometheus.io/docs/prometheus/latest/getting_started and https://devopscube.com/setup-prometheus-monitoring-on-kubernetes.

A list of Pod Metrics provided by kube-state-metrics can be found at https://github.com/kubernetes/kube-state-metrics/blob/master/docs/pod-metrics.md. 

Another option for getting Prometheus going using only Docker Compose and Docker Swarm can be found at:

https://github.com/vegasbrianc/prometheus

The yaml files used here were originally created by Bibin Wilson (thanks for the great work Bibin!) and documented at:
- https://devopscube.com/setup-prometheus-monitoring-on-kubernetes
- https://devopscube.com/setup-kube-state-metrics
- https://devopscube.com/setup-grafana-kubernetes/

