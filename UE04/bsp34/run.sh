#export MONO_TRACE_LISTENER=Console.Error
mcs -d:DEBUG *.cs -o main.exe
mono --debug main.exe
