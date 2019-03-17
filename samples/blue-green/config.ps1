process {
    Foreach-Object {
        $_ -replace "\`$TARGET_ROLE", $Env:TARGET_ROLE `
           -replace "\`$TOMCAT_VERSION", $Env:TOMCAT_VERSION
     }
}

# Must SET TARGET_ROLE and TOMCAT_VERSION in Powershell command window
# $Env:TARGET_ROLE="blue"
# $Env:TOMCAT_VERSION=7

# If there's an execution security error run to see the policy for Process 
# and/or CurrentUser
# Get-ExecutionPolicy

# If it doesn't show RemoteSigned (the default) then run the following:
# Set-ExecutionPolicy -ExecutionPolicy RemoteSigned

# To set for CurrentUser run:
# Set-ExecutionPolicy RemoteSigned -Scope CurrentUser

# Running inline example
# cat nginx.deployment.yml | %{ $_ -replace "\`$TARGET_ROLE", $Env:TARGET_ROLE } | %
# { $_ -replace "\`$TOMCAT_VERSION", $Env:TOMCAT_VERSION } | kubectl deploy -f -