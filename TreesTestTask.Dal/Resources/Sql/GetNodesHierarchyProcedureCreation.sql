CREATE
OR REPLACE FUNCTION get_nodes_hierarchy(RootName varchar(64))
    RETURNS TABLE
            (
                "Id"       INT,
                "Name"     varchar(64),
                "ParentId" INT,
                "TreeId"   INT
            )
    LANGUAGE plpgsql
AS
$$
BEGIN
RETURN QUERY(WITH RECURSIVE Tree AS (SELECT *
                                          FROM "Nodes" as node
                                          WHERE node."Name" = RootName
                                          UNION ALL
                                          SELECT n.*
                                          FROM "Nodes" n
                                                   INNER JOIN Tree ct ON n."ParentId" = ct."Id")
                  SELECT *
                  FROM Tree);
END;
$$;