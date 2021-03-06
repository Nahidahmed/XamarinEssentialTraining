Get-ChildItem .\ -include bin,obj -Recurse | foreach ($_) { remove-item $_.fullname -Force -Recurse } -ErrorAction SilentlyContinue

$packages = Get-ChildItem .\  -include packages -Recurse 
if(!$packages)
{
exit
}


$dirs = Get-ChildItem $packages -Directory 

foreach ($dir in $dirs) { [io.directory]::Delete($dir.fullname,$true)  }

$testresults= Get-ChildItem .\  -include TestResults -Recurse 
if(!$testresults)
{
exit
}


$dirs = Get-ChildItem $testresults -Directory 

foreach ($dir in $dirs) { [io.directory]::Delete($dir.fullname,$true)  }

$dirs = Get-ChildItem $.vs -Directory 

foreach ($dir in $dirs) { [io.directory]::Delete($dir.fullname,$true)  }

