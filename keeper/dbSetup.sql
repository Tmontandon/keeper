-- Active: 1666715466993@@SG-berry-server-8496-6844-mysql-master.servers.mongodirector.com@3306@SqlDb

CREATE TABLE
    IF NOT EXISTS accounts(
        id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
        createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
        updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
        name varchar(255) COMMENT 'User Name',
        email varchar(255) COMMENT 'User Email',
        picture varchar(255) COMMENT 'User Picture',
        coverImg MediumText COMMENT 'User CoverImg'
    ) default charset utf8 COMMENT '';

CREATE TABLE
    IF NOT EXISTS keeps(
        id int AUTO_INCREMENT NOT NULL primary key COMMENT 'primary key',
        createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
        updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
        creatorId VARCHAR(255) Not Null,
        name varchar(255) Not Null,
        description mediumtext Not Null,
        img mediumtext Not Null,
        views INT DEFAULT 0 check(views >= 0),
        Foreign Key (creatorId) REFERENCES accounts(id)
    ) default charset utf8 COMMENT '';

CREATE TABLE
    IF NOT EXISTS vaults(
        id int AUTO_INCREMENT NOT NULL primary key COMMENT 'primary key',
        createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
        updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
        creatorId VARCHAR(255) Not Null,
        name varchar(255) Not Null,
        description mediumtext Not Null,
        img mediumtext Not Null,
        isPrivate TINYINT DEFAULT 0,
        Foreign Key (creatorId) REFERENCES accounts(id)
    ) default charset utf8 COMMENT '';

CREATE TABLE
    IF NOT EXISTS vaultKeeps(
        id int AUTO_INCREMENT NOT NULL primary key COMMENT 'primary key',
        createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
        updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
        creatorId VARCHAR(255) Not Null,
        vaultId INT not null,
        keepId int not null,
        Foreign Key (creatorId) REFERENCES accounts(id),
        Foreign Key (vaultId) REFERENCES vaults(id) on delete CASCADE,
        Foreign Key (keepId) REFERENCES keeps(id) on delete cascade
    ) default charset utf8 COMMENT '';

-- Delete From keeps;

-- Delete From  vaults;

-- Delete From  vaultKeeps;