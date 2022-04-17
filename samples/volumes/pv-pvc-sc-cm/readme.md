#### Using a StorageClass, PersistentVolume, PersistentVolueClaim, and ConfigMap

This example shows different types of storage options that can be used. Because a local Kubernetes is running (with a single Node), we'll
only use the local-storage option, however in cloud scenarios the SC/PVC could be modififed as appropriate for the cloud provider's storage options.

## Running the MongoDB Deployment

### IMPORTANT: PersistentVolumes and MongoDB have problems on **Windows Docker Desktop**. The steps are being shown here for completeness, but there's a known issue so be aware!!!!

1. Create the following folder structure on your local system:

    **Mac Big Sur:** `/private/tmp/data/db`

    **Mac (earlier than Big Sur):** `/tmp/data/db`

    **Windows:**   `c:/temp/data/db`

    **Linux:** `/tmp/data/db`

2. Edit the `mongo.deployment.yml` and change the PVs local `path` to one of the following:

    **Windows:**  `/c/temp/data/db`. If you're using WSL with Docker desktop try using `/mnt/c/temp/data/db` or `/run/desktop/mnt/host/c/temp/data/db` (depending on your WSL version and setup)

    **Mac Big Sur+:** `/private/tmp/data/db`

    **Mac (pre Big Sur):** `/tmp/data/db`

    **Linux:** `/tmp/data/db`

3. Start up the Pod:

    `kubectl create -f mongo.deployment.yml`

4. Run `kubectl get pods` to see the pod.
5. Run `kubectl exec [mongo-pod-name] -it sh` to shell into the container. Run the `mongo` command to make sure the database is working. Type `exit` to exit the shell.

    Note: If you have a tool that can hit MongoDB externally you can `kubectl port-forward` to the pod to expose 27017.

6. Delete the mongo Pod: `kubectl delete pod [mongo-pod-name]`
7. Once the pod is deleted, run `kubectl get pv` and note the reclaim policy that's shown and the status (should show Bound since the policy was Retain)
8. Delete everything else: `kubectl delete -f mongo.deployment.yml`