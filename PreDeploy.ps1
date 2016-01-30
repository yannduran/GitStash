$branch = git branch --list | Select-String -Pattern "*" -SimpleMatch
$release = $branch -replace '\* release-([0-9\.\-]+)', '$1'

if($release)
{
	Write-Host "Making Release: $release"
}
else
{
	Write-Host "Couldn't determine version number."
	Exit
}

$assemblyVersion = 'AssemblyVersion("' +$release + '")]'

$newFile = Get-Content "SharedAssemblyInfo.cs" -encoding "UTF8" 
$newfile = $newfile -replace 'AssemblyVersion.*', $assemblyVersion
$newfile | set-Content "SharedAssemblyInfo.cs" -encoding "UTF8"

$xml = [xml](Get-Content "GitStash\source.extension.vsixmanifest")
$node = $xml.PackageManifest.Metadata.Identity | where {$_.Id -eq 'GitStash.Steve Przepiora.ea9024b9-bf82-48a2-9767-ffa183b4036e'}
$node.Version = $release
$xml.Save("GitStash\source.extension.vsixmanifest")