# MovieBase (Visual Studio & C#)
This is a Windows app for storing movie information (Created with C# and Visual Studio). This project is not finished yet.

The MySQL database consists of one table:
```
CREATE DATABASE DB;

use DB;

CREATE TABLE `movie` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(100) DEFAULT NULL,
  `Director` varchar(100) DEFAULT NULL,
  `ReleaseYear` varchar(100) DEFAULT NULL,
  `Note` varchar(300) DEFAULT NULL,
  `Review` int(11) DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=1 DEFAULT CHARSET=utf8;

```
