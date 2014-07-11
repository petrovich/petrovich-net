properties {
  $base_dir  = resolve-path .
  $src_dir = "$base_dir\src"
  $build_dir = "$base_dir\build"
  $release_dir = "$base_dir\bin"
  $tools_dir = "$base_dir\tools"
  $nuspec_dir = "$base_dir\nuget"
}

task default -depends Pack

task Clean {
  remove-item -force -recurse $build_dir -ErrorAction SilentlyContinue
  remove-item -force -recurse $release_dir -ErrorAction SilentlyContinue
}

task Restore {
  & $tools_dir\nuget\nuget.exe restore "$src_dir\NPetrovich.sln"
}

task Init -depends Clean, Restore {
  new-item $build_dir -itemType directory -ErrorAction SilentlyContinue
  new-item $release_dir -itemType directory -ErrorAction SilentlyContinue
}

task Compile -depends Init {
  exec { msbuild "$src_dir\NPetrovich.sln" /p:OutDir="$build_dir" }
}

task Test -depends Compile {
  & $tools_dir\NUnit.Runners\tools\nunit-console.exe "$build_dir\NPetrovich.Tests.dll" `
       /xml:"$build_dir\TestResult.xml"
}

task Merge {
  & $tools_dir\ILMerge\ILMerge.exe "$build_dir\NPetrovich.dll" `
        "$build_dir\YamlDotNet.Core.dll" `
        "$build_dir\YamlDotNet.RepresentationModel.dll" `
        /out:"$release_dir\NPetrovich.dll" `
        /t:library
  if ($lastExitCode -ne 0) {
        throw "Error: Failed to merge assemblies!"
  }
}

task Pack -depends Release {
  & $tools_dir\nuget\nuget.exe pack "$nuspec_dir\NPetrovich.dll.nuspec" `
      -OutputDirectory "$release_dir"
}

task Release -depends Test, Merge {
  Copy-Item "$build_dir\rules.yml" "$release_dir\rules.yml"
}
