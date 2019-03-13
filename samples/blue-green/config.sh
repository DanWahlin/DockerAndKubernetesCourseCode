sed 's/\$TARGET_ROLE'"/$TARGET_ROLE/g" |
sed 's/\$TOMCAT_VERSION'"/$TOMCAT_VERSION/g" |
tee

# To Run:
# cat nginx.deployment.yml | sh config.sh | kubectl create -f -