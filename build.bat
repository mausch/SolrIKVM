@echo off
set ikvmc="..\ikvm\ikvmc.exe"
set ikvm="..\ikvm"
cd jars
%ikvmc% -target:library geronimo-stax-api_1.0_spec-1.0.1.jar
%ikvmc% -target:library slf4j-jdk14-1.5.5.jar slf4j-api-1.5.5.jar
%ikvmc% -target:library -r:slf4j-jdk14-1.5.5.dll jcl-over-slf4j-1.5.5.jar
%ikvmc% -target:library commons-csv-1.0-SNAPSHOT-r609327.jar
%ikvmc% -target:library commons-codec-1.3.jar
%ikvmc% -target:library commons-io-1.4.jar
%ikvmc% -target:library -r:jcl-over-slf4j-1.5.5.dll -r:commons-codec-1.3.dll commons-httpclient-3.1.jar
%ikvmc% -target:library servlet-api-2.5-6.1.3.jar
%ikvmc% -target:library -r:servlet-api-2.5-6.1.3.dll -r:commons-io-1.4.dll commons-fileupload-1.2.1.jar
%ikvmc% -target:library lucene-core-2.9.3.jar
%ikvmc% -target:library -r:lucene-core-2.9.3.dll lucene-analyzers-2.9.3.jar
%ikvmc% -target:library -r:lucene-core-2.9.3.dll lucene-memory-2.9.3.jar
%ikvmc% -target:library -r:lucene-core-2.9.3.dll -r:lucene-memory-2.9.3.dll -r:%ikvm%\IKVM.OpenJDK.Text.dll -r:%ikvm%\IKVM.OpenJDK.Core.dll lucene-highlighter-2.9.3.jar
%ikvmc% -target:library -r:lucene-core-2.9.3.dll -r:%ikvm%\IKVM.OpenJDK.Text.dll -r:%ikvm%\IKVM.OpenJDK.Core.dll lucene-misc-2.9.3.jar
%ikvmc% -target:library -r:lucene-core-2.9.3.dll lucene-queries-2.9.3.jar
%ikvmc% -target:library -r:lucene-core-2.9.3.dll lucene-snowball-2.9.3.jar
%ikvmc% -target:library -r:lucene-core-2.9.3.dll lucene-spellchecker-2.9.3.jar
%ikvmc% -target:library -r:lucene-core-2.9.3.dll -r:commons-httpclient-3.1.dll -r:commons-io-1.4.dll -r:slf4j-jdk14-1.5.5.dll apache-solr-solrj-1.4.1.jar
%ikvmc% -target:library -r:servlet-api-2.5-6.1.3.dll jetty-util-6.1.3.jar
%ikvmc% -target:library -r:servlet-api-2.5-6.1.3.dll -r:jetty-util-6.1.3.dll jetty-6.1.3.jar
%ikvmc% -target:library -r:lucene-highlighter-2.9.3.dll -r:lucene-queries-2.9.3.dll -r:commons-fileupload-1.2.1.dll -r:commons-httpclient-3.1.dll -r:lucene-spellchecker-2.9.3.dll -r:commons-csv-1.0-SNAPSHOT-r609327.dll -r:servlet-api-2.5-6.1.3.dll -r:lucene-core-2.9.3.dll -r:slf4j-jdk14-1.5.5.dll -r:lucene-analyzers-2.9.3.dll -r:commons-io-1.4.dll -r:commons-codec-1.3.dll -r:lucene-snowball-2.9.3.dll -r:apache-solr-solrj-1.4.1.dll -r:jetty-6.1.3.dll -r:jetty-util-6.1.3.dll apache-solr-core-1.4.1.jar
cd ..
move jars\*.dll lib
msbuild