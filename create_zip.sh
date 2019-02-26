find ./src/HashCode \( -name "*.cs" -or -name "*.csproj" \) -not -path './**/obj/*' | tar -cvf solution.tar --files-from -
