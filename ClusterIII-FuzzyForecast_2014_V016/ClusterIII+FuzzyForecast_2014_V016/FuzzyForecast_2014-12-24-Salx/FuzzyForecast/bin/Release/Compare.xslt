<?xml version="1.0" encoding="windows-1251"?>
<xsl:stylesheet version="2.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:fn="http://www.w3.org/2005/xpath-functions" xmlns:xdt="http://www.w3.org/2005/xpath-datatypes" xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:altova="http://www.altova.com">
	<xsl:output version="4.0" method="html" indent="no" encoding="UTF-8" doctype-public="-//W3C//DTD HTML 4.0 Transitional//EN" doctype-system="http://www.w3.org/TR/html4/loose.dtd"/>
	<xsl:param name="SV_OutputFormat" select="'HTML'"/>
	<xsl:variable name="XML" select="/"/>
	<xsl:template match="/">
		<html>
			<head>
				<title>Сравнение моделей</title>
			</head>
			<body>
				<xsl:for-each select="$XML">
                    Результат сравнения моделей
					<table border="1">
						<thead>
							<tr>
								<th>
									<span>
										<xsl:text>Модель</xsl:text>
									</span>
								</th>
								<th>
									<span>
										<xsl:text>iMSE</xsl:text>
									</span>
								</th>
								<th>
									<span>
										<xsl:text>iMAPE</xsl:text>
									</span>
								</th>
                                <th>
									<span>
										<xsl:text>iFPE</xsl:text>
									</span>
								</th>
								<th>
									<span>
										<xsl:text>iTFPE</xsl:text>
									</span>
								</th>
                                <th>
									<span>
										<xsl:text>iRFPE</xsl:text>
									</span>
								</th>
								<th>
									<span>
										<xsl:text>eMSE</xsl:text>
									</span>
								</th>
								<th>
									<span>
										<xsl:text>eMAPE</xsl:text>
									</span>
								</th>
                                <th>
									<span>
										<xsl:text>eFPE</xsl:text>
									</span>
								</th>
								<th>
									<span>
										<xsl:text>eTFPE</xsl:text>
									</span>
								</th>
                                <th>
									<span>
										<xsl:text>eRFPE</xsl:text>
									</span>
								</th>
							</tr>
						</thead>
						<tbody>
							<xsl:for-each select="ArrayOfCompareRow">
								<xsl:for-each select="CompareRow">
									<tr>
										<td>
											<xsl:for-each select="Model">
												<xsl:apply-templates/>
											</xsl:for-each>
										</td>
										<td>
											<xsl:for-each select="iMSE">
												<xsl:apply-templates/>
											</xsl:for-each>
										</td>
										<td>
											<xsl:for-each select="iMAPE">
												<xsl:apply-templates/>
											</xsl:for-each>
										</td>
                                        <td>
											<xsl:for-each select="iFPE">
												<xsl:apply-templates/>
											</xsl:for-each>
										</td>
                                        <td>
											<xsl:for-each select="iTFPE">
												<xsl:apply-templates/>
											</xsl:for-each>
										</td>
                                        <td>
											<xsl:for-each select="iRFPE">
												<xsl:apply-templates/>
											</xsl:for-each>
										</td>
                                        <td>
											<xsl:for-each select="eMSE">
												<xsl:apply-templates/>
											</xsl:for-each>
										</td>
										<td>
											<xsl:for-each select="eMAPE">
												<xsl:apply-templates/>
											</xsl:for-each>
										</td>
                                        <td>
											<xsl:for-each select="eFPE">
												<xsl:apply-templates/>
											</xsl:for-each>
										</td>
                                        <td>
											<xsl:for-each select="eTFPE">
												<xsl:apply-templates/>
											</xsl:for-each>
										</td>
                                        <td>
											<xsl:for-each select="eRFPE">
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
