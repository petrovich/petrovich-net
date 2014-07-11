$base_dir = resolve-path .
$psake_dir = "$base_dir\tools\psake"
$build_file = "$base_dir\build.ps1"

Import-Module (join-path $psake_dir psake.psm1)
invoke-psake $build_file
