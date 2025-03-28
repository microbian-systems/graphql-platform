# Query_Brands_First_2_And_Products_First_2_Name_Desc

## Result

```json
{
  "data": {
    "brands": {
      "nodes": [
        {
          "id": "QnJhbmQ6MTE=",
          "name": "Zephyr",
          "products": {
            "nodes": [
              {
                "id": "UHJvZHVjdDo0OA==",
                "name": "Trailblazer 45L Backpack"
              },
              {
                "id": "UHJvZHVjdDoyMw==",
                "name": "Summit Pro Climbing Harness"
              }
            ]
          }
        },
        {
          "id": "QnJhbmQ6MTM=",
          "name": "XE",
          "products": {
            "nodes": [
              {
                "id": "UHJvZHVjdDo3Nw==",
                "name": "Survivor 2-Person Tent"
              },
              {
                "id": "UHJvZHVjdDo4MA==",
                "name": "Pathfinder GPS Watch"
              }
            ]
          }
        }
      ]
    }
  }
}
```

## Query 1

```sql
-- @__p_0='3'
SELECT b."Id", b."Name"
FROM "Brands" AS b
ORDER BY b."Name" DESC, b."Id"
LIMIT @__p_0
```

## Query 2

```sql
-- @__brandIds_0={ '11', '13' } (DbType = Object)
SELECT p."BrandId" AS "Key", count(*)::int AS "Count"
FROM "Products" AS p
WHERE p."BrandId" = ANY (@__brandIds_0)
GROUP BY p."BrandId"
```

## Query 3

```sql
-- @__brandIds_0={ '11', '13' } (DbType = Object)
SELECT t."BrandId", t0."Id", t0."Name", t0."BrandId"
FROM (
    SELECT p."BrandId"
    FROM "Products" AS p
    WHERE p."BrandId" = ANY (@__brandIds_0)
    GROUP BY p."BrandId"
) AS t
LEFT JOIN (
    SELECT t1."Id", t1."Name", t1."BrandId"
    FROM (
        SELECT p0."Id", p0."Name", p0."BrandId", ROW_NUMBER() OVER(PARTITION BY p0."BrandId" ORDER BY p0."Name" DESC, p0."Id") AS row
        FROM "Products" AS p0
        WHERE p0."BrandId" = ANY (@__brandIds_0)
    ) AS t1
    WHERE t1.row <= 3
) AS t0 ON t."BrandId" = t0."BrandId"
ORDER BY t."BrandId", t0."BrandId", t0."Name" DESC, t0."Id"
```

