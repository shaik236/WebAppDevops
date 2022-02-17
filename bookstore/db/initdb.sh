#!/bin/bash
set -e
export PGPASSWORD=$POSTGRES_PASSWORD;
psql -v ON_ERROR_STOP=1 --username "$POSTGRES_USER" --dbname "$POSTGRES_DB" <<-EOSQL
  CREATE USER $APP_DB_USER WITH PASSWORD '$APP_DB_PASS';
  CREATE DATABASE $APP_DB_NAME;
  GRANT ALL PRIVILEGES ON DATABASE $APP_DB_NAME TO $APP_DB_USER;
  \connect $APP_DB_NAME $APP_DB_USER
  BEGIN;
    CREATE TABLE IF NOT EXISTS techbook (
	  id bigint NOT NULL PRIMARY KEY,
	  name CHAR(100) NOT NULL CHECK (CHAR_LENGTH(name) = 100),
	  value bigint
	);
	CREATE INDEX idx_techbook_id ON techbook (id);
  COMMIT;
EOSQL