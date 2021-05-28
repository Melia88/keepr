CREATE TABLE IF NOT EXISTS profiles (
  id VARCHAR (255) NOT NULL primary key COMMENT 'primary key',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  name VARCHAR (255) NOT NULL COMMENT 'User Name',
  email VARCHAR (255) UNIQUE NOT NULL COMMENT 'User Email',
  picture VARCHAR (255) COMMENT 'User Picture'
);
CREATE TABLE IF NOT EXISTS vaults(
  id INT NOT NULL primary key AUTO_INCREMENT COMMENT 'primary key',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  creatorId VARCHAR (255) NOT NULL COMMENT 'FK: User Profile',
  name VARCHAR (255) COMMENT 'Vaults Name',
  description VARCHAR (255) COMMENT 'Vaults Description',
  isPrivate Boolean COMMENT 'Is This a Private or Public Vault',
  FOREIGN KEY (creatorId) REFERENCES profiles(id) ON DELETE CASCADE
);
CREATE TABLE IF NOT EXISTS keeps(
  id int NOT NULL primary key AUTO_INCREMENT COMMENT 'primary key',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  creatorId VARCHAR(255) NOT NULL COMMENT 'FK: User ProfileId',
  name VARCHAR (255) NOT NULL COMMENT 'Keeps Name',
  description VARCHAR(255) COMMENT 'Keeps Description',
  img VARCHAR(255) COMMENT 'Keeps Image',
  views INT COMMENT 'Keeps View Count',
  shares INT COMMENT 'Keeps Share Count',
  keeps INT COMMENT 'Keeps Total Count',
  FOREIGN KEY (creatorId) REFERENCES profiles(id) ON DELETE CASCADE
);
CREATE TABLE IF NOT EXISTS vault_keeps(
  id int NOT NULL primary key AUTO_INCREMENT COMMENT 'primary key',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  creatorId varchar(255) NOT NULL COMMENT 'FK: User ProfileId',
  vaultId INT NOT NULL COMMENT 'FK: Vaults ID',
  keepsId INT NOT NULL COMMENT 'FK: Keeps ID',
  FOREIGN KEY (creatorId) REFERENCES profiles(id) ON DELETE CASCADE,
  FOREIGN KEY (vaultId) REFERENCES vaults(id) ON DELETE CASCADE,
  FOREIGN KEY (keepsId) REFERENCES keeps(id) ON DELETE CASCADE
);
-- The profiles table takes the place of accuonts but is the same thing