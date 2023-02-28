# highload-backend-v1
## SQL 
```sql
create table users (
	id varchar(36) primary key,
	name varchar(50),
	email varchar(50)
);

create table products (
	id varchar(36) primary key,
	name varchar(50),
	price integer,
	count integer,
	description text
);

create table cart (
	customer varchar(36) REFERENCES users (id),
	products varchar(36) REFERENCES products (id)
);

create table orders (
	id varchar(36) primary key,
	customer varchar(36) REFERENCES users (id),
	description text
);

create table orders_elements (
	order_id varchar(36) REFERENCES orders(id),
	element_id varchar(36) REFERENCES products(id)
);

```
