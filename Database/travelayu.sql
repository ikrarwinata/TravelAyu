-- phpMyAdmin SQL Dump
-- version 5.0.2
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1:3306
-- Generation Time: Sep 23, 2021 at 11:49 AM
-- Server version: 5.7.31
-- PHP Version: 7.3.21

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `travelayu`
--

-- --------------------------------------------------------

--
-- Table structure for table `jadwal`
--

DROP TABLE IF EXISTS `jadwal`;
CREATE TABLE IF NOT EXISTS `jadwal` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `hari` varchar(50) NOT NULL,
  `jam` varchar(10) NOT NULL,
  `id_tujuan` int(11) NOT NULL,
  `mobil` varchar(8) NOT NULL,
  `indextanggal` int(4) NOT NULL DEFAULT '107',
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=16 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `jadwal`
--

INSERT INTO `jadwal` (`id`, `hari`, `jam`, `id_tujuan`, `mobil`, `indextanggal`) VALUES
(5, 'Senin', '09:00', 2, 'BH0900WA', 109),
(4, 'Senin', '07:00', 1, 'BH0900WA', 107),
(6, 'Senin', '08:00', 2, 'BH0900WA', 108),
(7, 'Selasa', '08:00', 1, 'BH090WW', 208),
(8, 'Rabu', '08:00', 1, 'BH090WW', 308),
(9, 'Rabu', '12:00', 2, 'BH0900WA', 312),
(10, 'Rabu', '08:00', 1, 'BH0900WA', 308),
(11, 'Jumat', '11:00', 1, 'BH090WW', 511),
(12, 'Jumat', '15:00', 5, '222', 515),
(13, 'Minggu', '00:00', 3, '222', 700),
(14, 'Minggu', '20:00', 1, 'BH090WW', 720),
(15, 'Kamis', '18:00', 3, 'BH0900WA', 418);

-- --------------------------------------------------------

--
-- Table structure for table `kursi_tiket`
--

DROP TABLE IF EXISTS `kursi_tiket`;
CREATE TABLE IF NOT EXISTS `kursi_tiket` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `id_tiket` int(11) NOT NULL,
  `seats` varchar(100) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=50 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `kursi_tiket`
--

INSERT INTO `kursi_tiket` (`id`, `id_tiket`, `seats`) VALUES
(36, 4, 'R0;C1'),
(35, 4, 'R0;C0'),
(47, 10, 'R1;C0'),
(46, 10, 'R0;C0'),
(32, 2, 'R1;C1'),
(31, 2, 'R1;C0'),
(30, 1, 'R0;C1'),
(29, 1, 'R0;C0'),
(37, 5, 'R1;C0'),
(38, 5, 'R1;C1'),
(39, 6, 'R1;C0'),
(40, 6, 'R1;C1'),
(41, 7, 'R0;C0'),
(42, 8, 'R1;C0'),
(43, 8, 'R1;C1'),
(44, 9, 'R0;C0'),
(45, 9, 'R0;C1'),
(48, 10, 'R1;C1'),
(49, 11, 'R2;C0');

-- --------------------------------------------------------

--
-- Table structure for table `mobil`
--

DROP TABLE IF EXISTS `mobil`;
CREATE TABLE IF NOT EXISTS `mobil` (
  `nopol` varchar(8) NOT NULL,
  `nama_mobil` varchar(100) NOT NULL,
  `warna` varchar(100) NOT NULL,
  `NIK_supir` varchar(21) NOT NULL,
  `kursi_depan` int(2) NOT NULL DEFAULT '1',
  `kursi_2` int(2) NOT NULL DEFAULT '0',
  `kursi_3` int(2) NOT NULL DEFAULT '0',
  `kursi_4` int(2) NOT NULL DEFAULT '0',
  `kapasitas` float NOT NULL DEFAULT '10',
  PRIMARY KEY (`nopol`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Dumping data for table `mobil`
--

INSERT INTO `mobil` (`nopol`, `nama_mobil`, `warna`, `NIK_supir`, `kursi_depan`, `kursi_2`, `kursi_3`, `kursi_4`, `kapasitas`) VALUES
('BH0900WA', 'Avanza', 'Hitam', '2343243', 1, 2, 3, 0, 48),
('BH090WW', 'mobil2', 'putih', '01923012930', 2, 2, 2, 3, 20),
('222', 'toyota', 'hitam', '3333', 2, 3, 3, 3, 25);

-- --------------------------------------------------------

--
-- Table structure for table `pengguna`
--

DROP TABLE IF EXISTS `pengguna`;
CREATE TABLE IF NOT EXISTS `pengguna` (
  `username` varchar(25) NOT NULL,
  `password` varchar(100) NOT NULL,
  `nama` varchar(100) NOT NULL,
  `hp` varchar(21) DEFAULT NULL,
  `level` enum('admin','manajer') NOT NULL DEFAULT 'admin',
  PRIMARY KEY (`username`),
  UNIQUE KEY `username` (`username`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Dumping data for table `pengguna`
--

INSERT INTO `pengguna` (`username`, `password`, `nama`, `hp`, `level`) VALUES
('admin', '21232f297a57a5a743894a0e4a801fc3', 'admin', '0909090909', 'admin'),
('owner', '72122ce96bfec66e2396d2e25225d70a', 'owner', '090909090', 'manajer'),
('kasir', 'c7911af3adbd12a035b289556d96470a', 'kasir', '0909090900909', 'admin');

-- --------------------------------------------------------

--
-- Stand-in structure for view `penjualan_tiket_view`
-- (See below for the actual view)
--
DROP VIEW IF EXISTS `penjualan_tiket_view`;
CREATE TABLE IF NOT EXISTS `penjualan_tiket_view` (
`id_tiket` int(11)
,`NIK_penumpang` varchar(25)
,`tanggal` varchar(21)
,`timestamps` varchar(100)
,`ID` int(11)
,`Hari` varchar(50)
,`Jam` varchar(10)
,`Tujuan` text
,`Mobil` varchar(202)
,`NomorPolisi` varchar(8)
,`Kapasitas` bigint(14)
,`NIK Supir` varchar(25)
,`Supir` varchar(100)
,`TotalPenumpang` bigint(21)
,`Total` double
,`TerBayar` float
,`Status` varchar(11)
);

-- --------------------------------------------------------

--
-- Table structure for table `penumpang`
--

DROP TABLE IF EXISTS `penumpang`;
CREATE TABLE IF NOT EXISTS `penumpang` (
  `NIK` varchar(25) NOT NULL,
  `nama` varchar(100) NOT NULL,
  `tempat_lahir` varchar(25) NOT NULL,
  `tanggal_lahir` varchar(15) NOT NULL,
  `jenis_kelamin` enum('Pria','Wanita') NOT NULL,
  `email` varchar(50) DEFAULT NULL,
  `hp` varchar(20) DEFAULT NULL,
  PRIMARY KEY (`NIK`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Dumping data for table `penumpang`
--

INSERT INTO `penumpang` (`NIK`, `nama`, `tempat_lahir`, `tanggal_lahir`, `jenis_kelamin`, `email`, `hp`) VALUES
('090912090890', 'Penumpang1', 'jambi', '01/01/1997', 'Pria', 'mail@nail.com', '09090909'),
('0980890987', 'Penumpang baru', 'jambi', '01/01/1997', 'Pria', '-', '4564564'),
('243243', 'wewrre', 'jambi', '01/01/1997', 'Pria', 'qwewqe', '88778'),
('213556547', 'byu', 'jambi', '21/01/1997', 'Wanita', 'wruyewyr7y', '5477547475');

-- --------------------------------------------------------

--
-- Table structure for table `supir`
--

DROP TABLE IF EXISTS `supir`;
CREATE TABLE IF NOT EXISTS `supir` (
  `NIK` varchar(25) NOT NULL,
  `nama` varchar(100) NOT NULL,
  `hp` varchar(21) NOT NULL,
  PRIMARY KEY (`NIK`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Dumping data for table `supir`
--

INSERT INTO `supir` (`NIK`, `nama`, `hp`) VALUES
('01923012930', 'Supir baru', '909090090'),
('2343243', 'sopir2', '234324'),
('3333', 'anton', '2222'),
('111', 'bayu', '0000');

-- --------------------------------------------------------

--
-- Table structure for table `tarif`
--

DROP TABLE IF EXISTS `tarif`;
CREATE TABLE IF NOT EXISTS `tarif` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `tujuan` text NOT NULL,
  `tarif` float NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=6 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tarif`
--

INSERT INTO `tarif` (`id`, `tujuan`, `tarif`) VALUES
(1, 'Riau', 100000),
(2, 'Pekanbaru', 150000),
(3, 'Padang', 180000),
(5, 'Jambi', 100000);

-- --------------------------------------------------------

--
-- Table structure for table `tiket`
--

DROP TABLE IF EXISTS `tiket`;
CREATE TABLE IF NOT EXISTS `tiket` (
  `id` int(11) NOT NULL,
  `penumpang` varchar(25) NOT NULL,
  `id_jadwal` int(11) NOT NULL,
  `tanggal` varchar(21) NOT NULL,
  `timestamps` varchar(100) NOT NULL,
  `total` float NOT NULL DEFAULT '0',
  `bayar` float NOT NULL DEFAULT '0',
  `dibatalkan` tinyint(1) NOT NULL DEFAULT '0',
  `berat_barang` float NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tiket`
--

INSERT INTO `tiket` (`id`, `penumpang`, `id_jadwal`, `tanggal`, `timestamps`, `total`, `bayar`, `dibatalkan`, `berat_barang`) VALUES
(4, '243243', 14, '18/07/2021', '1626634417959', 100000, 200000, 1, 0),
(2, '0980890987', 13, '18/07/2021', '1626633932733', 180000, 360000, 0, 0),
(1, '2222', 13, '18/07/2021', '1626633520067', 180000, 360000, 0, 0),
(5, '2222', 6, '19/07/2021', '1626725541604', 150000, 300000, 0, 0),
(6, '213556547', 8, '21/07/2021', '1626875475501', 100000, 100000, 0, 0),
(7, '213556547', 8, '21/07/2021', '1626875514573', 100000, 100000, 0, 0),
(8, '213556547', 7, '24/08/2021', '1629798996111', 100000, 200000, 0, 0),
(9, '2222', 7, '21/09/2021', '1632230672660', 100000, 200000, 0, 0),
(10, '213556547', 15, '23/09/2021', '1632422633266', 180000, 550000, 0, 0),
(11, '213556547', 15, '23/09/2021', '1632422770048', 180000, 1000, 0, 12);

-- --------------------------------------------------------

--
-- Stand-in structure for view `tiket_view`
-- (See below for the actual view)
--
DROP VIEW IF EXISTS `tiket_view`;
CREATE TABLE IF NOT EXISTS `tiket_view` (
`ID` int(11)
,`Hari` varchar(50)
,`Jam` varchar(10)
,`Tujuan` text
,`Mobil` varchar(202)
,`Nomor Polisi` varchar(8)
,`Kapasitas` bigint(14)
,`NIK Supir` varchar(25)
,`Supir` varchar(100)
);

-- --------------------------------------------------------

--
-- Structure for view `penjualan_tiket_view`
--
DROP TABLE IF EXISTS `penjualan_tiket_view`;

DROP VIEW IF EXISTS `penjualan_tiket_view`;
CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `penjualan_tiket_view`  AS  select `a`.`id` AS `id_tiket`,`a`.`penumpang` AS `NIK_penumpang`,`a`.`tanggal` AS `tanggal`,`a`.`timestamps` AS `timestamps`,`c`.`ID` AS `ID`,`c`.`Hari` AS `Hari`,`c`.`Jam` AS `Jam`,`c`.`Tujuan` AS `Tujuan`,`c`.`Mobil` AS `Mobil`,`c`.`Nomor Polisi` AS `NomorPolisi`,`c`.`Kapasitas` AS `Kapasitas`,`c`.`NIK Supir` AS `NIK Supir`,`c`.`Supir` AS `Supir`,count(`b`.`seats`) AS `TotalPenumpang`,sum(`a`.`total`) AS `Total`,`a`.`bayar` AS `TerBayar`,if((`a`.`dibatalkan` = 1),'DIBATALKAN',if((`a`.`bayar` >= sum(`a`.`total`)),'LUNAS','BELUM LUNAS')) AS `Status` from ((`tiket` `a` left join `kursi_tiket` `b` on((`a`.`id` = `b`.`id_tiket`))) left join `tiket_view` `c` on((`a`.`id_jadwal` = `c`.`ID`))) group by `a`.`id` ;

-- --------------------------------------------------------

--
-- Structure for view `tiket_view`
--
DROP TABLE IF EXISTS `tiket_view`;

DROP VIEW IF EXISTS `tiket_view`;
CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `tiket_view`  AS  select `a`.`id` AS `ID`,`a`.`hari` AS `Hari`,`a`.`jam` AS `Jam`,`b`.`tujuan` AS `Tujuan`,concat(`c`.`nama_mobil`,', ',`c`.`warna`) AS `Mobil`,`c`.`nopol` AS `Nomor Polisi`,(((`c`.`kursi_depan` + `c`.`kursi_2`) + `c`.`kursi_3`) + `c`.`kursi_4`) AS `Kapasitas`,`d`.`NIK` AS `NIK Supir`,`d`.`nama` AS `Supir` from (((`jadwal` `a` join `tarif` `b` on((`a`.`id_tujuan` = `b`.`id`))) join `mobil` `c` on((`a`.`mobil` = `c`.`nopol`))) join `supir` `d` on((`c`.`NIK_supir` = `d`.`NIK`))) order by `a`.`indextanggal` ;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
