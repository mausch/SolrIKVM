@echo off
set ikvmc="..\ikvm\ikvmc.exe"
set ikvm="..\ikvm"
cd jars
%ikvmc% -target:library servlet-api-2.5-6.1.3.jar
%ikvmc% -target:library commons-lang-2.4.jar
%ikvmc% -target:library commons-collections-3.2.1.jar
%ikvmc% -target:library slf4j-jdk14-1.5.5.jar slf4j-api-1.5.5.jar
%ikvmc% -target:library jakarta-regexp-1.5.jar
%ikvmc% -target:library geronimo-stax-api_1.0_spec-1.0.1.jar
%ikvmc% -target:library commons-csv-1.0-SNAPSHOT-r966014.jar
%ikvmc% -target:library commons-codec-1.4.jar
%ikvmc% -target:library commons-io-1.4.jar
%ikvmc% -target:library apache-solr-noggit-r944541.jar
%ikvmc% -target:library lucene-core-3.1.0.jar
%ikvmc% -target:library -r:commons-lang-2.4.dll -r:commons-collections-3.2.1.dll -r:servlet-api-2.5-6.1.3.dll -r:slf4j-jdk14-1.5.5.dll velocity-1.6.1.jar
%ikvmc% -target:library -r:velocity-1.6.1.dll -r:commons-lang-2.4.dll -r:commons-collections-3.2.1.dll -r:servlet-api-2.5-6.1.3.dll velocity-tools-2.0-beta3.jar
%ikvmc% -target:library -r:slf4j-jdk14-1.5.5.dll jcl-over-slf4j-1.5.5.jar
%ikvmc% -target:library -r:jcl-over-slf4j-1.5.5.dll -r:commons-codec-1.4.dll commons-httpclient-3.1.jar
%ikvmc% -target:library -r:servlet-api-2.5-6.1.3.dll -r:commons-io-1.4.dll commons-fileupload-1.2.1.jar
%ikvmc% -target:library -r:lucene-core-3.1.0.dll lucene-analyzers-3.1.0.jar
%ikvmc% -target:library -r:lucene-core-3.1.0.dll lucene-memory-3.1.0.jar
%ikvmc% -target:library -r:lucene-core-3.1.0.dll -r:lucene-memory-3.1.0.dll -r:%ikvm%\IKVM.OpenJDK.Text.dll -r:%ikvm%\IKVM.OpenJDK.Core.dll lucene-highlighter-3.1.0.jar
%ikvmc% -target:library -r:lucene-core-3.1.0.dll -r:%ikvm%\IKVM.OpenJDK.Text.dll -r:%ikvm%\IKVM.OpenJDK.Core.dll lucene-misc-3.1.0.jar
%ikvmc% -target:library -r:lucene-core-3.1.0.dll -r:jakarta-regexp-1.5.dll lucene-queries-3.1.0.jar
%ikvmc% -target:library -r:lucene-core-3.1.0.dll -r:lucene-queries-3.1.0.dll lucene-spatial-3.1.0.jar
%ikvmc% -target:library -r:lucene-core-3.1.0.dll lucene-spellchecker-3.1.0.jar
%ikvmc% -target:library -r:lucene-core-3.1.0.dll -r:commons-httpclient-3.1.dll -r:commons-io-1.4.dll -r:slf4j-jdk14-1.5.5.dll apache-solr-solrj-3.1.0.jar
%ikvmc% -target:library -r:servlet-api-2.5-6.1.3.dll jetty-util-6.1.3.jar
%ikvmc% -target:library -r:servlet-api-2.5-6.1.3.dll -r:jetty-util-6.1.3.dll jetty-6.1.3.jar
%ikvmc% -target:library -r:velocity-1.6.1.dll -r:velocity-tools-2.0-beta3.dll -r:lucene-highlighter-3.1.0.dll -r:lucene-queries-3.1.0.dll -r:lucene-spatial-3.1.0.dll -r:commons-collections-3.2.1.dll -r:commons-fileupload-1.2.1.dll -r:commons-httpclient-3.1.dll -r:lucene-spellchecker-3.1.0.dll -r:commons-csv-1.0-SNAPSHOT-r966014.dll -r:servlet-api-2.5-6.1.3.dll -r:lucene-core-3.1.0.dll -r:slf4j-jdk14-1.5.5.dll -r:lucene-analyzers-3.1.0.dll -r:commons-io-1.4.dll -r:commons-codec-1.4.dll -r:apache-solr-solrj-3.1.0.dll -r:jetty-6.1.3.dll -r:jetty-util-6.1.3.dll -r:apache-solr-noggit-r944541.dll apache-solr-core-3.1.0.jar
cd ..
move jars\*.dll lib
msbuild