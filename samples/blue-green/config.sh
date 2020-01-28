sed 's/\$TARGET_ROLE'"/$TARGET_ROLE/g" |
sed 's/\$IMAGE_VERSION'"/$IMAGE_VERSION/g" |
tee

# Must SET TARGET_ROLE and IMAGE_VERSION in command window
# export TARGET_ROLE=blue
# export IMAGE_VERSION=nginx-blue

# To run deployment:
# cat nginx.deployment.yml | sh config.sh | kubectl create --save-config -f -
# cat nginx.service.yml | sh config.sh | kubectl create --save-config -f -
# kubectl create -f nginx-blue-test.service.yml --save-config

# To run for green change the environment vars and run the same steps above