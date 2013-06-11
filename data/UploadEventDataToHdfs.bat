
rem Create directory for event data on HDFS
hadoop fs -mkdir /user/Camper/input/EventData

rem Upload content of local EventData directory into HDFS
hadoop fs -put EventData\* /user/Camper/input/EventData
