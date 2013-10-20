properties {
  $base_dir  = resolve-path ..\..\..
  $src_dir = "$base_dir\src"
  $project_file = "$src_dir\NPetrovich\NPetrovich.csproj"
  $buildartifacts_dir = "$base_dir\build"
  $release_dir = "$base_dir\bin"
  $tools_dir = "$base_dir\tools"
}

task default -depends Compile

task Clean {
  remove-item -force -recurse $buildartifacts_dir -ErrorAction SilentlyContinue
  remove-item -force -recurse $release_dir -ErrorAction SilentlyContinue
}

task Restore {
  & $tools_dir\nuget\nuget.exe restore "$src_dir\NPetrovich.sln"
}

task Init -depends Clean, Restore {
}

task Compile -depends Init {
  exec { msbuild "$project_file" /p:OutDir="$buildartifacts_dir" }
}

# task Test -depends Compile {
#   $old = pwd
#   cd $build_dir
#   exec ".\MbUnit.Cons.exe" "$build_dir\Rhino.Mocks.Tests.dll"
#   cd $old
# }

# task Merge {
#     $old = pwd
#     cd $build_dir

#     Remove-Item Rhino.Mocks.Partial.dll -ErrorAction SilentlyContinue
#     Rename-Item $build_dir\Rhino.Mocks.dll Rhino.Mocks.Partial.dll

#     & $tools_dir\ILMerge.exe Rhino.Mocks.Partial.dll `
#         Castle.DynamicProxy2.dll `
#         Castle.Core.dll `
#         /out:Rhino.Mocks.dll `
#         /t:library `
#         "/keyfile:$base_dir\ayende-open-source.snk" `
#         "/internalize:$base_dir\ilmerge.exclude"
#     if ($lastExitCode -ne 0) {
#         throw "Error: Failed to merge assemblies!"
#     }
#     cd $old
# }

# task Release -depends Test, Merge {
#     & $tools_dir\zip.exe -9 -A -j `
#         $release_dir\Rhino.Mocks.zip `
#         $build_dir\Rhino.Mocks.dll `
#         $build_dir\Rhino.Mocks.xml `
#         license.txt `
#         acknowledgements.txt
#     if ($lastExitCode -ne 0) {
#         throw "Error: Failed to execute ZIP command"
#     }
# }
