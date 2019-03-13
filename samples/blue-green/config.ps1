foreach ($i in $input) {
    Foreach-Object {
        $i -replace "\`$TARGET_ROLE", $Env:TARGET_ROLE `
           -replace "\`$TOMCAT_VERSION", $Env:TOMCAT_VERSION
     }
}

# To Run:
# cat nginx.deployment.yml | ./config.ps1 | kubectl create -f -

# Example of inlining
# cat nginx.deployment.yml | %{ $_ -replace "\`$TARGET_ROLE", $Env:TARGET_ROLE } | %
# { $_ -replace "\`$TOMCAT_VERSION", $Env:TOMCAT_VERSION } | kubectl create -f -