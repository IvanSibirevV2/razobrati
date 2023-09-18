<?xml version="1.0" encoding="windows-1251"?>
<xsl:stylesheet version="2.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:fn="http://www.w3.org/2005/xpath-functions" xmlns:xdt="http://www.w3.org/2005/xpath-datatypes" xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:altova="http://www.altova.com">
	<xsl:output version="4.0" method="html" indent="no" encoding="UTF-8" doctype-public="-//W3C//DTD HTML 4.0 Transitional//EN" doctype-system="http://www.w3.org/TR/html4/loose.dtd"/>
	<xsl:param name="SV_OutputFormat" select="'HTML'"/>
	<xsl:variable name="XML" select="/"/>
	<xsl:import-schema schema-location="ModelResults.xsd"/>
	<xsl:template match="/">
		<html>
			<head>
				<title>Временной ряд</title>
			</head>
			<body>
				<xsl:for-each select="$XML">
                    Результаты применения модели
					<table border="1">
						<thead>
							<tr>
								<th>
									<span>
										<xsl:text>Время</xsl:text>
									</span>
								</th>
								<th>
									<span>
										<xsl:text>Ряд</xsl:text>
									</span>
								</th>
								<th>
									<span>
										<xsl:text>Разность</xsl:text>
									</span>
								</th>
							</tr>
						</thead>
						<tbody>
							<xsl:for-each select="ArrayOfCrispNResultRow">
								<xsl:for-each select="CrispNResultRow">
									<tr>
										<td>
											<xsl:for-each select="Time">
												<xsl:apply-templates/>
											</xsl:for-each>
										</td>
										<td>
											<xsl:for-each select="Series">
												<xsl:apply-templates/>
											</xsl:for-each>
										</td>
										<td>
											<xsl:for-each select="Diff">
												<xsl:apply-templates/>
											</xsl:for-each>
										</td>
									</tr>
								</xsl:for-each>
							</xsl:for-each>
						</tbody>
					</table>
				</xsl:for-each>
			</body>
		</html>
	</xsl:template>
</xsl:stylesheet>
