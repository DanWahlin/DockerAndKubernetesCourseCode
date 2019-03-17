sed 's/\$TARGET_ROLE'"/$TARGET_ROLE/g" |
sed 's/\$TOMCAT_VERSION'"/$TOMCAT_VERSION/g" |
tee

# Must SET TARGET_ROLE and TOMCAT_VERSION in command window
# export TARGET_ROLE=blue
# export TOMCAT_VERSION=7

# To Run:
# cat nginx.deployment.yml | sh config.sh | kubectl create -f -