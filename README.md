Personal Blogs Application
# 1.Discription

## Why do this project

Using project to inhance C# and ASP.NET CORE learning. Basic functions including create,delete,
edit, search.

# 2.Database design

Blogs 

```sql
id
title
created time
blog type(ID)
blog view count
like count
Author Id
```

Blogs type

```sql
id
type name
```

Author

```sql
id
name
account
password

```

# 3.Structure Design

	DataWarehouse (DW)
	datawarehouse service(DWS)