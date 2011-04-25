@echo off
set ikvmc="..\ikvm\ikvmc.exe"
set ikvm="..\ikvm"
cd jars
%ikvmc% -out:..\lib\solr.dll -target:library servlet-api-2.5-6.1.3.jar commons-lang-2.4.jar commons-collections-3.2.1.jar slf4j-jdk14-1.5.5.jar slf4j-api-1.5.5.jar jakarta-regexp-1.5.jar geronimo-stax-api_1.0_spec-1.0.1.jar commons-csv-1.0-SNAPSHOT-r966014.jar commons-codec-1.4.jar commons-io-1.4.jar apache-solr-noggit-r944541.jar lucene-core-3.1.0.jar velocity-1.6.1.jar jcl-over-slf4j-1.5.5.jar commons-httpclient-3.1.jar commons-fileupload-1.2.1.jar lucene-analyzers-3.1.0.jar lucene-memory-3.1.0.jar lucene-highlighter-3.1.0.jar lucene-misc-3.1.0.jar lucene-queries-3.1.0.jar lucene-spatial-3.1.0.jar lucene-spellchecker-3.1.0.jar  apache-solr-solrj-3.1.0.jar jetty-util-6.1.3.jar jetty-6.1.3.jar apache-solr-core-3.1.0.jar
cd ..
move jars\*.dll lib
msbuild