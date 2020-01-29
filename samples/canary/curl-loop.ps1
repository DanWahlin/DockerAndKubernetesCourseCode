For ($i=0; $i -le 25; $i++) {
    $html = Invoke-WebRequest http://localhost 
    $html.Content -split "[`r`n]" | select-string "<title>.*</title>"
    Start-Sleep -s .5
}