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
  img VARCHAR(255) COMMENT 'Vaults Image',
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
  keepId INT NOT NULL COMMENT 'FK: Keeps ID',
  FOREIGN KEY (creatorId) REFERENCES profiles(id) ON DELETE CASCADE,
  FOREIGN KEY (vaultId) REFERENCES vaults(id) ON DELETE CASCADE,
  FOREIGN KEY (keepId) REFERENCES keeps(id) ON DELETE CASCADE
);
SELECT
  k.*,
  vk.id AS VaultKeepsId,
  p.*,
  vk.*
FROM
  vault_keeps vk
  JOIN keeps k ON k.id = vk.keepId
  JOIN profiles p ON k.creatorId = p.id
WHERE
  vk.vaultId = 36;
-- The profiles table takes the place of accuonts but is the same thing
  /* SELECT
        k.*,
        v.name as vaultName,
        v.description as vaultsDescription,
        v.creatorId as creatorId,
        vk.Id as vaultKeepsId,
        vk.vaultId as vaultId,
        vk.keepsId as keepsId
      FROM
        vault_keeps vk
        JOIN vaults v ON v.id = vk.vaultId
        JOIN keeps k ON k.id = vk.keepsId
      WHERE
        vk.vaultId = @id;
      INSERT INTO
        keeps(name, description)
      VALUES
        ("please", "work");
      SELECT
        LAST_INSERT_ID();
      SELECT
        k.*,
        p.*
      FROM
        keeps k
        JOIN profiles p ON p.id = k.creatorId;
      SELECT
        v.*,
        p.*
      From
        vaults v
        JOIN profiles p ON p.id = v.creatorId
      WHERE
        v.id = 1;
      INSERT INTO
        vaults (creatorId, name, description)
      VALUES
        (
          "9b1fabde-0565-432c-aeea-318a95a5fcd7",
          "id check",
          "some stuff"
        );
      SELECT
        *
      FROM
        vaults
      WHERE
        id = 52;
      SELECT
        v.*,
        v.id as vaultId,
        p.*
      From
        vaults v
        JOIN profiles p ON p.id = v.creatorId
      WHERE
        v.id = 52; */