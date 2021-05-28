CREATE TABLE IF NOT EXISTS accounts (
  id VARCHAR (255) NOT NULL primary key COMMENT 'primary key',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  name VARCHAR (255) NOT NULL COMMENT 'User Name',
  email VARCHAR (255) NOT NULL COMMENT 'User Email',
  picture VARCHAR (255) COMMENT 'User Picture'
);
CREATE TABLE IF NOT EXISTS [NAME](
  id INT NOT NULL primary key AUTO_INCREMENT COMMENT 'primary key',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  ownerId VARCHAR (255) NOT NULL COMMENT 'FK: User Account',
  name VARCHAR (255) COMMENT 'Restaurants Name',
  location VARCHAR (255) COMMENT 'Restaurants Location',
  FOREIGN KEY (ownerId) REFERENCES accounts(id) ON DELETE CASCADE
);
CREATE TABLE IF NOT EXISTS [NAME](
  id int NOT NULL primary key AUTO_INCREMENT COMMENT 'primary key',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  creatorId varchar(255) NOT NULL COMMENT 'FK: User Account',
  restaurantId INT NOT NULL COMMENT 'FK: User Account',
  title varchar(255) COMMENT 'Reviews Title',
  body varchar(255) COMMENT 'Reviews Body',
  rating INT COMMENT '1-5 star Rating',
  FOREIGN KEY (creatorId) REFERENCES accounts(id) ON DELETE CASCADE,
  FOREIGN KEY (restaurantId) REFERENCES restaurants(id) ON DELETE CASCADE
);
-- creatorId is the same as ownerId