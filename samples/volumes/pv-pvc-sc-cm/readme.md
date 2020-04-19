#### Using a StorageClass, PersistentVolume, PersistentVolueClaim, and ConfigMap

This example shows different types of storage options that can be used. Because a local Kubernetes is running (with a single Node), we'll
only use the local-storage option, however in cloud scenarios the SC/PVC could be modififed as appropriate for the cloud provider's storage options.

## Running the MongoDB Deployment

### IMPORTANT: PersistentVolumes and MongoDB have problems on **Windows Docker Desktop**. The steps are being shown here for completeness, but there's a known issue so be aware!!!!

1. Create the following folder structure on your local system:

Mac/Linux: /tmp/data/db
Windows:   c:/temp/data/db

2. If you're on Windows go into `mongo.deployment.yml` and change the PVs local path to /c/temp/data/db. Save the file.

3. Start up the Pod:

    `kubectl create -f mongo.deployment.yml`

4. Run `kubectl get pods` to see the pod.
5. Run `kubectl exec [mongo-pod-name] -it sh` to shell into the container. Run the `mongo` command to make sure the database is working. Type `exit` to exit the shell.

    Note: If you have a tool that can hit MongoDB externally you can `kubectl port-forward` to the pod to expose 27017.

6. Delete the mongo Pod: `kubectl delete pod [mongo-pod-name]`
7. Once the pod is deleted, run `kubectl get pv` and note the reclaim policy that's shown and the status (should show Bound since the policy was Retain)
8. Delete everything else: `kubectl delete -f mongo.deployment.yml`