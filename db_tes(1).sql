-- phpMyAdmin SQL Dump
-- version 4.3.11
-- http://www.phpmyadmin.net
--
-- Host: 127.0.0.1
-- Generation Time: Oct 30, 2015 at 04:47 AM
-- Server version: 5.6.24
-- PHP Version: 5.6.8

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Database: `db_tes`
--

-- --------------------------------------------------------

--
-- Table structure for table `tblactivity`
--

CREATE TABLE IF NOT EXISTS `tblactivity` (
  `activityID` int(11) NOT NULL,
  `name` varchar(50) NOT NULL
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tblactivity`
--

INSERT INTO `tblactivity` (`activityID`, `name`) VALUES
(1, 'Coding'),
(2, 'BPR'),
(3, 'UAT'),
(4, 'Meeting'),
(5, 'Other Activity');

-- --------------------------------------------------------

--
-- Table structure for table `tblbillability`
--

CREATE TABLE IF NOT EXISTS `tblbillability` (
  `billabilityID` int(11) NOT NULL,
  `positionID` int(11) NOT NULL,
  `activityID` int(11) NOT NULL,
  `billable` tinyint(1) NOT NULL
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tblbillability`
--

INSERT INTO `tblbillability` (`billabilityID`, `positionID`, `activityID`, `billable`) VALUES
(1, 1, 1, 1),
(2, 2, 2, 0),
(3, 5, 2, 1),
(4, 4, 2, 1);

-- --------------------------------------------------------

--
-- Table structure for table `tblbusinessunit`
--

CREATE TABLE IF NOT EXISTS `tblbusinessunit` (
  `id` int(11) NOT NULL,
  `name` varchar(50) NOT NULL
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tblbusinessunit`
--

INSERT INTO `tblbusinessunit` (`id`, `name`) VALUES
(1, 'XRM'),
(2, 'GP'),
(3, 'AX'),
(4, 'DMBS');

-- --------------------------------------------------------

--
-- Table structure for table `tblentry`
--

CREATE TABLE IF NOT EXISTS `tblentry` (
  `id` int(11) NOT NULL,
  `userID` int(11) NOT NULL,
  `billabilityID` int(11) NOT NULL,
  `salesorderid` int(11) NOT NULL,
  `week` int(11) NOT NULL,
  `description` varchar(150) NOT NULL,
  `isFinal` tinyint(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `tblentrydetails`
--

CREATE TABLE IF NOT EXISTS `tblentrydetails` (
  `id` int(11) NOT NULL,
  `entryID` int(11) NOT NULL,
  `date` date NOT NULL,
  `start` time NOT NULL,
  `end` time NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `tblposition`
--

CREATE TABLE IF NOT EXISTS `tblposition` (
  `positionID` int(11) NOT NULL,
  `name` varchar(50) NOT NULL
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tblposition`
--

INSERT INTO `tblposition` (`positionID`, `name`) VALUES
(1, 'Software Engineer'),
(2, 'Functional Consultant'),
(3, 'Lead Software Engineer'),
(4, 'Business Head Unit'),
(5, 'Project Manager');

-- --------------------------------------------------------

--
-- Table structure for table `tblsalesorder`
--

CREATE TABLE IF NOT EXISTS `tblsalesorder` (
  `id` int(11) NOT NULL,
  `name` varchar(50) NOT NULL,
  `managerid` int(11) NOT NULL,
  `teamid` int(11) NOT NULL,
  `status` tinyint(1) NOT NULL,
  `businessunitid` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `tblteam`
--

CREATE TABLE IF NOT EXISTS `tblteam` (
  `id` int(11) NOT NULL,
  `name` varchar(50) NOT NULL
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tblteam`
--

INSERT INTO `tblteam` (`id`, `name`) VALUES
(1, 'Exodus'),
(2, 'Dog Food'),
(3, 'DHCM'),
(4, 'Dynamic Pay'),
(5, 'IPI'),
(6, 'MCC');

-- --------------------------------------------------------

--
-- Table structure for table `tbluser`
--

CREATE TABLE IF NOT EXISTS `tbluser` (
  `userID` int(11) NOT NULL,
  `name` varchar(50) NOT NULL,
  `positionID` int(11) NOT NULL,
  `businessunitID` int(11) NOT NULL,
  `teamid` int(11) NOT NULL
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tbluser`
--

INSERT INTO `tbluser` (`userID`, `name`, `positionID`, `businessunitID`, `teamid`) VALUES
(1, 'Rex', 1, 1, 1),
(2, 'Feye', 2, 2, 2),
(3, 'Jhun', 3, 3, 3),
(4, 'Daniel', 4, 1, 1),
(5, 'Reggie', 5, 2, 2);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `tblactivity`
--
ALTER TABLE `tblactivity`
  ADD PRIMARY KEY (`activityID`);

--
-- Indexes for table `tblbillability`
--
ALTER TABLE `tblbillability`
  ADD PRIMARY KEY (`billabilityID`);

--
-- Indexes for table `tblbusinessunit`
--
ALTER TABLE `tblbusinessunit`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `tblposition`
--
ALTER TABLE `tblposition`
  ADD PRIMARY KEY (`positionID`);

--
-- Indexes for table `tblsalesorder`
--
ALTER TABLE `tblsalesorder`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `tblteam`
--
ALTER TABLE `tblteam`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `tbluser`
--
ALTER TABLE `tbluser`
  ADD PRIMARY KEY (`userID`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `tblactivity`
--
ALTER TABLE `tblactivity`
  MODIFY `activityID` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=6;
--
-- AUTO_INCREMENT for table `tblbillability`
--
ALTER TABLE `tblbillability`
  MODIFY `billabilityID` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=5;
--
-- AUTO_INCREMENT for table `tblbusinessunit`
--
ALTER TABLE `tblbusinessunit`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=5;
--
-- AUTO_INCREMENT for table `tblposition`
--
ALTER TABLE `tblposition`
  MODIFY `positionID` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=6;
--
-- AUTO_INCREMENT for table `tblsalesorder`
--
ALTER TABLE `tblsalesorder`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT for table `tblteam`
--
ALTER TABLE `tblteam`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=7;
--
-- AUTO_INCREMENT for table `tbluser`
--
ALTER TABLE `tbluser`
  MODIFY `userID` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=6;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
