for ((i=1;i<=100;i++)); 
do
    curl -s "http://localhost" | grep "<title>.*</title>"
    sleep 2s
done