process {
    Foreach-Object {
        $_ -Replace "\`$TARGET_ROLE", $Env:TARGET_ROLE `
           -Replace "\`$IMAGE_VERSION", $Env:IMAGE_VERSION
     }
}

# Must SET TARGET_ROLE and IMAGE_VERSION in Powershell command window
# $Env:TARGET_ROLE="blue"
# $Env:IMAGE_VERSION=nginx-blue

# If there's an execution security error run to see the policy for Process 
# and/or CurrentUser
# Get-ExecutionPolicy

# If it doesn't show RemoteSigned (the default) then run the following:
# Set-ExecutionPolicy -ExecutionPolicy RemoteSigned

# To set for CurrentUser run:
# Set-ExecutionPolicy RemoteSigned -Scope CurrentUser

# To run deployment:

# cat nginx.deployment.yml | ./config.ps1 | kubectl create --save-config -f -
# cat nginx.service.yml | ./config.ps1 | kubectl create --save-config -f -
# kubectl create -f nginx-blue-test.service.yml

# To run deployment (harder way...but left in for posterities sake):
# cat nginx.deployment.yml | %{ $_ -replace "\`$TARGET_ROLE", $Env:TARGET_ROLE } | %{ $_ -replace "\`$IMAGE_VERSION", $Env:IMAGE_VERSION } | kubectl create -f -
# cat nginx.service.yml | %{ $_ -replace "\`$TARGET_ROLE", $Env:TARGET_ROLE } | %{ $_ -replace "\`$IMAGE_VERSION", $Env:IMAGE_VERSION } | kubectl create -f -
# kubectl create -f nginx-blue-test.service.yml

# To run for green change the environment vars and run the same steps above