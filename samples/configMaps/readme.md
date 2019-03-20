## Techniques for working with ConfigMaps

1. Using a k8s CM manifest:  `kubectl create -f settings.configmap.yml`
2. Load settings from a file: `kubectl create cm app-settings --from-file=settings.properties`. Will add file name as key into ConfigMap data. Will NOT add quotes around non-string values.
3. Load settings from an env file: `kubectl create cm app-settings --from-env-file=settings.properties`. Will NOT add file name as key into ConfigMap data. Will add quotes around non-string values.
4. Define settings in kubectl command: `kubectl create cm app-settings --from-literal=apiUurl=https://my-api  --from-literal=otherKey=otherValue --from-literal=count=50`. Will add quotes around non-string values.



