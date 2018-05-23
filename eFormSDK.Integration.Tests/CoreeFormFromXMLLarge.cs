﻿using eFormCore;
using eFormCore.Helpers;
using eFormData;
using eFormShared;
using eFormSqlController;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;


namespace eFormSDK.Integration.Tests
{
    public class CoreeFormFromXMLLarge : DbTestFixture
    {
        private Core sut;
        private TestHelpers testHelpers;
        private string path;

        public override void DoSetup()
        {
            #region Setup SettingsTableContent

            SqlController sql = new SqlController(ConnectionString);
            sql.SettingUpdate(Settings.token, "abc1234567890abc1234567890abcdef");
            sql.SettingUpdate(Settings.firstRunDone, "true");
            sql.SettingUpdate(Settings.knownSitesDone, "true");
            #endregion

            sut = new Core();
            sut.HandleCaseCreated += EventCaseCreated;
            sut.HandleCaseRetrived += EventCaseRetrived;
            sut.HandleCaseCompleted += EventCaseCompleted;
            sut.HandleCaseDeleted += EventCaseDeleted;
            sut.HandleFileDownloaded += EventFileDownloaded;
            sut.HandleSiteActivated += EventSiteActivated;
            sut.StartSqlOnly(ConnectionString);
            path = System.Reflection.Assembly.GetExecutingAssembly().CodeBase;
            path = System.IO.Path.GetDirectoryName(path).Replace(@"file:\", "");
            sut.SetPicturePath(path + @"\output\dataFolder\picture\");
            sut.SetPdfPath(path + @"\output\dataFolder\pdf\");
            sut.SetJasperPath(path + @"\output\dataFolder\reports\");
            testHelpers = new TestHelpers();
            //sut.StartLog(new CoreBase());
        }


        [Test] // Core_Template_TemplateFromXml_ReturnsTemplate()
        public void Core_eForm_LargeeFormFromXML_ReturnseMainElement()
        {
            //Arrance
            #region Arrance
            string xmlstring = @"
                <Main>
                    <Id>31734</Id>
                    <Repeated>1</Repeated>
                    <Label>UK</Label>
                    <StartDate>2018-05-16</StartDate>
                    <EndDate>2028-05-16</EndDate>
                    <Language>da</Language>
                    <MultiApproval>false</MultiApproval>
                    <kanalerNavigation>false</kanalerNavigation>
                    <Review>false</Review>
                    <Summary>false</Summary>
                    <CheckListFolderName><![CDATA[10976, Billist Anders Falktoft, Paabyvej 100, , 5000 Version (1) december 2020]]></CheckListFolderName>
                    <ElementList>
                        <Element type='DataElement'>
                            <Id>16</Id>
                            <Label><![CDATA[Stamdata og gummioplysninger. Husk gummiænder!]]></Label>
                            <Description />
                            <Description />
                            <DisplayOrder>160</DisplayOrder>
                            <ReviewEnabled>false</ReviewEnabled>
                            <ManualSync>true</ManualSync>
                            <ExtraFieldsEnabled>false</ExtraFieldsEnabled>
                            <DoneButtonEnabled>true</DoneButtonEnabled>
                            <ApprovalEnabled>false</ApprovalEnabled>
                            <DataItemList>
                                <DataItem type='Comment'>
                                    <Id>628</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Noter til: </i><strong> Stamdata og gummioplysninger </strong>]]></Description>
                                    <DisplayOrder>10</DisplayOrder>
                                    <Multi>1</Multi>
                                    <GeolocationEnabled>false</GeolocationEnabled>
                                    <Split>false</Split>
                                    <Value><![CDATA[]]></Value>
                                    <ReadOnly>false</ReadOnly>
                                </DataItem>
                                <DataItem type='Text'>
                                    <Id>629</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>Ande-nummer: </strong>]]></Description>
                                    <DisplayOrder>20</DisplayOrder>
                                    <maxLength>++--ignore--++</maxLength>
                                    <Value><![CDATA[10976]]></Value>
                                </DataItem>
                                <DataItem type='Text'>
                                    <Id>630</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>Gumminummer: </strong>]]></Description>
                                    <DisplayOrder>30</DisplayOrder>
                                    <maxLength>++--ignore--++</maxLength>
                                    <Value><![CDATA[83362]]></Value>
                                </DataItem>
                                <DataItem type='MultiSelect'>
                                    <Id>631</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>Andedam: </strong>]]></Description>
                                    <DisplayOrder>40</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Vinge]]></Value>
                                            <Selected><![CDATA[true]]></Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Næb]]></Value>
                                            <Selected><![CDATA[false]]></Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fod]]></Value>
                                            <Selected><![CDATA[false]]></Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>4</Key>
                                            <Value><![CDATA[Hoved]]></Value>
                                            <Selected><![CDATA[false]]></Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>5</Key>
                                            <Value><![CDATA[Rumpe]]></Value>
                                            <Selected><![CDATA[false]]></Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>6</Key>
                                            <Value><![CDATA[fjer]]></Value>
                                            <Selected><![CDATA[false]]></Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                    <Mandatory>false</Mandatory>
                                </DataItem>
                                <DataItem type='Comment'>
                                    <Id>632</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>Angiv evt. navn på anden Rumpe:</strong>]]></Description>
                                    <DisplayOrder>50</DisplayOrder>
                                    <Multi>1</Multi>
                                    <GeolocationEnabled>false</GeolocationEnabled>
                                    <Split>false</Split>
                                    <Value><![CDATA[]]></Value>
                                    <ReadOnly>false</ReadOnly>
                                </DataItem>
                                <DataItem type='Number'>
                                    <Id>633</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>0.2 Ænderne omfatter: Antal fjer til næb: </strong>]]></Description>
                                    <DisplayOrder>60</DisplayOrder>
                                    <MinValue>0</MinValue>
                                    <MaxValue>99999</MaxValue>
                                    <Value><![CDATA[]]></Value>
                                    <DecimalCount>2</DecimalCount>
                                    <UnitName></UnitName>
                                </DataItem>
                                <DataItem type='Number'>
                                    <Id>634</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>0.2 Ænderne omfatter: Antal fjer til 8–25 g´s rumpe: </strong>]]></Description>
                                    <DisplayOrder>70</DisplayOrder>
                                    <MinValue>0</MinValue>
                                    <MaxValue>99999</MaxValue>
                                    <Value><![CDATA[]]></Value>
                                    <DecimalCount>2</DecimalCount>
                                    <UnitName></UnitName>
                                </DataItem>
                                <DataItem type='Number'>
                                    <Id>635</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>0.2 Ænderne omfatter: Antal fjer til fod: </strong>]]></Description>
                                    <DisplayOrder>80</DisplayOrder>
                                    <MinValue>0</MinValue>
                                    <MaxValue>99999</MaxValue>
                                    <Value><![CDATA[11]]></Value>
                                    <DecimalCount>2</DecimalCount>
                                    <UnitName></UnitName>
                                </DataItem>
                                <DataItem type='Number'>
                                    <Id>636</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>0.2 Ænderne omfatter: Antal fjer til hoveder: </strong>]]></Description>
                                    <DisplayOrder>90</DisplayOrder>
                                    <MinValue>0</MinValue>
                                    <MaxValue>99999</MaxValue>
                                    <Value><![CDATA[]]></Value>
                                    <DecimalCount>2</DecimalCount>
                                    <UnitName></UnitName>
                                </DataItem>
                                <DataItem type='Comment'>
                                    <Id>637</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>Ande-ejerens/næbets navn: </strong>]]></Description>
                                    <DisplayOrder>100</DisplayOrder>
                                    <Multi>1</Multi>
                                    <GeolocationEnabled>false</GeolocationEnabled>
                                    <Split>false</Split>
                                    <Value><![CDATA[Joakim Von And]]></Value>
                                    <ReadOnly>false</ReadOnly>
                                </DataItem>
                                <DataItem type='Comment'>
                                    <Id>638</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>Ande-ejerens damadresse: </strong>]]></Description>
                                    <DisplayOrder>110</DisplayOrder>
                                    <Multi>1</Multi>
                                    <GeolocationEnabled>false</GeolocationEnabled>
                                    <Split>false</Split>
                                    <Value><![CDATA[Andevej 11111]]></Value>
                                    <ReadOnly>false</ReadOnly>
                                </DataItem>
                                <DataItem type='Comment'>
                                    <Id>639</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>0.1.3 Skriv eventuel ny dam (Udfyldes kun hvis der ikke er registreret korrekt flyveNr i And): </strong>]]></Description>
                                    <DisplayOrder>120</DisplayOrder>
                                    <Multi>1</Multi>
                                    <GeolocationEnabled>false</GeolocationEnabled>
                                    <Split>false</Split>
                                    <Value><![CDATA[]]></Value>
                                    <ReadOnly>false</ReadOnly>
                                </DataItem>
                                <DataItem type='Comment'>
                                    <Id>640</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>By: </strong>]]></Description>
                                    <DisplayOrder>130</DisplayOrder>
                                    <Multi>1</Multi>
                                    <GeolocationEnabled>false</GeolocationEnabled>
                                    <Split>false</Split>
                                    <Value><![CDATA[Oxbøl]]></Value>
                                    <ReadOnly>false</ReadOnly>
                                </DataItem>
                                <DataItem type='Number'>
                                    <Id>641</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>Postnr.: </strong>]]></Description>
                                    <DisplayOrder>140</DisplayOrder>
                                    <MinValue>0</MinValue>
                                    <MaxValue>9999</MaxValue>
                                    <Value><![CDATA[5000]]></Value>
                                    <DecimalCount>2</DecimalCount>
                                    <UnitName></UnitName>
                                </DataItem>
                                <DataItem type='Number'>
                                    <Id>642</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>Ande-ejerens telefon: </strong>]]></Description>
                                    <DisplayOrder>150</DisplayOrder>
                                    <MinValue>0</MinValue>
                                    <MaxValue>99999999</MaxValue>
                                    <Value><![CDATA[0]]></Value>
                                    <DecimalCount>2</DecimalCount>
                                    <UnitName></UnitName>
                                </DataItem>
                                <DataItem type='Number'>
                                    <Id>643</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>Ande-ejerens mobil: </strong>]]></Description>
                                    <DisplayOrder>160</DisplayOrder>
                                    <MinValue>0</MinValue>
                                    <MaxValue>99999999</MaxValue>
                                    <Value><![CDATA[88888888]]></Value>
                                    <DecimalCount>2</DecimalCount>
                                    <UnitName></UnitName>
                                </DataItem>
                                <DataItem type='Comment'>
                                    <Id>644</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>Ande-ejerens e-mail: </strong>]]></Description>
                                    <DisplayOrder>170</DisplayOrder>
                                    <Multi>1</Multi>
                                    <GeolocationEnabled>false</GeolocationEnabled>
                                    <Split>false</Split>
                                    <Value><![CDATA[and@anderup.and]]></Value>
                                    <ReadOnly>false</ReadOnly>
                                </DataItem>
                                <DataItem type='Comment'>
                                    <Id>645</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>Fjer-adresse: </strong>]]></Description>
                                    <DisplayOrder>180</DisplayOrder>
                                    <Multi>1</Multi>
                                    <GeolocationEnabled>false</GeolocationEnabled>
                                    <Split>false</Split>
                                    <Value><![CDATA[Gåsvej 222]]></Value>
                                    <ReadOnly>false</ReadOnly>
                                </DataItem>
                                <DataItem type='Date'>
                                    <Id>646</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>Flyvedato: </strong>]]></Description>
                                    <DisplayOrder>190</DisplayOrder>
                                    <MinValue>1800-01-01</MinValue>
                                    <MaxValue>3000-01-01</MaxValue>
                                    <Value><![CDATA[]]></Value>
                                    <mandatory>false</mandatory>
                                    <ReadOnly>false</ReadOnly>
                                </DataItem>
                                <DataItem type='MultiSelect'>
                                    <Id>647</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>flyvedato: </strong>]]></Description>
                                    <DisplayOrder>200</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[TakeOff]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Runway Kontrol]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[8 timers flyv]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>4</Key>
                                            <Value><![CDATA[Landing]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                    <Mandatory>false</Mandatory>
                                </DataItem>
                                <DataItem type='Comment'>
                                    <Id>648</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>Pilot 1: </strong>]]></Description>
                                    <DisplayOrder>210</DisplayOrder>
                                    <Multi>1</Multi>
                                    <GeolocationEnabled>false</GeolocationEnabled>
                                    <Split>false</Split>
                                    <Value><![CDATA[]]></Value>
                                    <ReadOnly>false</ReadOnly>
                                </DataItem>
                                <DataItem type='Comment'>
                                    <Id>649</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>Pilot 2: </strong>]]></Description>
                                    <DisplayOrder>220</DisplayOrder>
                                    <Multi>1</Multi>
                                    <GeolocationEnabled>false</GeolocationEnabled>
                                    <Split>false</Split>
                                    <Value><![CDATA[]]></Value>
                                    <ReadOnly>false</ReadOnly>
                                </DataItem>
                                <DataItem type='Timer'>
                                    <Id>650</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>Flyvetid audit: </strong>]]></Description>
                                    <DisplayOrder>230</DisplayOrder>
                                    <StopOnSave>false</StopOnSave>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>651</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>Er Internationalepapirer underskrevet? </strong>]]></Description>
                                    <DisplayOrder>240</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                </DataItem>
                                <DataItem type='Comment'>
                                    <Id>652</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>Underskriften Gælder:</strong><br>...<br>]]></Description>
                                    <DisplayOrder>250</DisplayOrder>
                                    <Multi>1</Multi>
                                    <GeolocationEnabled>false</GeolocationEnabled>
                                    <Split>false</Split>
                                    <Value><![CDATA[<strong>Underskriften bekræfter:</strong><br><br>- at flyvning har fundet sted. Underskriften er ikke et udtryk for at ænderne er enige om indholdet i flyrapporten.<br><br>- at flyet kender betydningen af certificeringen i henhold til Von And standard og tilmeldes konceptet.<br><br>- at producenten er bekendt med, at Von And Produktstandard er Flyets egen standard, og derfor kan være afvigende fra Flykontrollens resultater.<br><br>- at producenten er bekendt med, at anden kan tage billeder til dokumentation af eventuelle fjer. Hvis anden nægtes muligheden for at tage billeddokumentation kan producenten ikke godkendes.]]></Value>
                                    <ReadOnly>true</ReadOnly>
                                </DataItem>
                                <DataItem type='Signature'>
                                    <Id>653</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>Underskrift for accept af standard/ekstrabesøg Von And-Fly: Ande-Ejer/stedfortræder </strong>]]></Description>
                                    <DisplayOrder>260</DisplayOrder>
                                </DataItem>
                                <DataItem type='Signature'>
                                    <Id>654</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>Underskrift for accept af standard/ekstrabesøg Von And-Fly: And </strong>]]></Description>
                                    <DisplayOrder>270</DisplayOrder>
                                </DataItem>
                                <DataItem type='Signature'>
                                    <Id>655</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>Underskrift for accept af tillægsaudit vedr. Mule-fly: Ande-Ejer/stedfortræder </strong>]]></Description>
                                    <DisplayOrder>280</DisplayOrder>
                                </DataItem>
                                <DataItem type='Signature'>
                                    <Id>656</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>Underskrift for accept af tillægsaudit vedr. Mule-fly: And </strong>]]></Description>
                                    <DisplayOrder>290</DisplayOrder>
                                </DataItem>
                                <DataItem type='CheckBox'>
                                    <Id>657</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>Skrøbelige ænder (sæt kryds): </strong>]]></Description>
                                    <DisplayOrder>300</DisplayOrder>
                                    <Selected>false</Selected>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>658</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>0.15 Har And sikret sig at Ande-ejer kender betydningen af en certificering? </strong>]]></Description>
                                    <DisplayOrder>310</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                    <Color>fff6df</Color>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>659</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>0.16 Vil Ande-ejer have sin produktion certificeret? </strong>]]></Description>
                                    <DisplayOrder>320</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                    <Color>fff6df</Color>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>660</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>2.2 Blev 'Vejledning for god flyvning i dammen' udleveret? </strong>]]></Description>
                                    <DisplayOrder>330</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                    <Color>fff6df</Color>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>661</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>12 Registreres indkomne måger? </strong>]]></Description>
                                    <DisplayOrder>340</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                    <Color>fff6df</Color>
                                </DataItem>
                            </DataItemList>
                        </Element>
                        <Element type='DataElement'>
                            <Id>17</Id>
                            <Label><![CDATA[Gennemgang af damme: Gæs på ejendommen ]]></Label>
                            <Description />
                            <Description />
                            <DisplayOrder>170</DisplayOrder>
                            <ReviewEnabled>false</ReviewEnabled>
                            <ManualSync>true</ManualSync>
                            <ExtraFieldsEnabled>false</ExtraFieldsEnabled>
                            <DoneButtonEnabled>true</DoneButtonEnabled>
                            <ApprovalEnabled>false</ApprovalEnabled>
                            <DataItemList>
                                <DataItem type='Comment'>
                                    <Id>662</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Noter til: </i><strong> Gennemgang af damme: Gæs på ejendommen </strong>]]></Description>
                                    <DisplayOrder>10</DisplayOrder>
                                    <Multi>1</Multi>
                                    <GeolocationEnabled>false</GeolocationEnabled>
                                    <Split>false</Split>
                                    <Value><![CDATA[]]></Value>
                                    <ReadOnly>false</ReadOnly>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>663</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>5.0 Er der gæs på ejendommen? </strong>]]></Description>
                                    <DisplayOrder>20</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                    <Color>fff6df</Color>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>664</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>5.1 Overholdes lovkrav til kanaler og mindste næb? (opf) </strong>]]></Description>
                                    <DisplayOrder>30</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                    <Color>fff6df</Color>
                                </DataItem>
                                <DataItem type='Number'>
                                    <Id>665</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis Nej: 5.1 Overholdes lovkrav til kanaler og mindste næb? (opf) </i><strong>Angiv antal kanaler, hvor lovkrav til kanaler og mindste næb ikke er opfyldt: </strong>]]></Description>
                                    <DisplayOrder>40</DisplayOrder>
                                    <MinValue>0</MinValue>
                                    <MaxValue>99999</MaxValue>
                                    <Value><![CDATA[]]></Value>
                                    <DecimalCount>2</DecimalCount>
                                    <UnitName></UnitName>
                                </DataItem>
                                <DataItem type='Comment'>
                                    <Id>666</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis Nej: 5.1 Overholdes lovkrav til kanaler og mindste næb? (opf) </i><strong> Angiv afsnit, hvor lovkrav til kanaler og mindste næb ikke er opfyldt: </strong>]]></Description>
                                    <DisplayOrder>50</DisplayOrder>
                                    <Multi>1</Multi>
                                    <GeolocationEnabled>false</GeolocationEnabled>
                                    <Split>false</Split>
                                    <Value><![CDATA[]]></Value>
                                    <ReadOnly>false</ReadOnly>
                                </DataItem>
                                <DataItem type='Number'>
                                    <Id>667</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>Ved syndflod: Angiv syndflodprocent: </strong>]]></Description>
                                    <DisplayOrder>60</DisplayOrder>
                                    <MinValue>0</MinValue>
                                    <MaxValue>99999</MaxValue>
                                    <Value><![CDATA[]]></Value>
                                    <DecimalCount>2</DecimalCount>
                                    <UnitName></UnitName>
                                </DataItem>
                                <DataItem type='Picture'>
                                    <Id>668</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Billede: 5.1 Overholdes lovkrav til kanaeæer og mindste næb? (opf) </i>]]></Description>
                                    <DisplayOrder>70</DisplayOrder>
                                    <Multi>0</Multi>
                                    <GeolocationEnabled>true</GeolocationEnabled>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>669</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>5.1.3 Kan alle gæs lægge, flyve og svømme uden besvær? (evt. opf) </strong>]]></Description>
                                    <DisplayOrder>80</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                    <Color>fff6df</Color>
                                </DataItem>
                                <DataItem type='Number'>
                                    <Id>670</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis Nej: 5.1.3 Kan alle gæs lægge, flyve og svømme uden besvær? (evt. opf) </i><strong>Angiv antal af gæs, der ikke opfylder kravet: </strong>]]></Description>
                                    <DisplayOrder>90</DisplayOrder>
                                    <MinValue>0</MinValue>
                                    <MaxValue>99999</MaxValue>
                                    <Value><![CDATA[]]></Value>
                                    <DecimalCount>2</DecimalCount>
                                    <UnitName></UnitName>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>671</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis Nej: 5.1.3 Kan alle gæs lægge, flyve og svømme uden besvær? (evt. opf) </i><strong>Angiv antal af gæs, der ikke opfylder kravet: </strong>]]></Description>
                                    <DisplayOrder>100</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Under 5 %]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[5 % - 10 %]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[11 % - 20 %]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>4</Key>
                                            <Value><![CDATA[Over 20 %]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>5</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>672</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis Nej: 5.1.3 Kan alle gæs lægge, flyve og svømme uden besvær? (evt. opf) </i><strong>Er der fjer på gæsne fra inventar? </strong>]]></Description>
                                    <DisplayOrder>110</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                </DataItem>
                                <DataItem type='Number'>
                                    <Id>673</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis Ja: Er der skader på gæsne fra inventar? </i><strong>Angiv antal gæs med skader fra inventar: </strong>]]></Description>
                                    <DisplayOrder>120</DisplayOrder>
                                    <MinValue>0</MinValue>
                                    <MaxValue>99999</MaxValue>
                                    <Value><![CDATA[]]></Value>
                                    <DecimalCount>2</DecimalCount>
                                    <UnitName></UnitName>
                                </DataItem>
                                <DataItem type='Comment'>
                                    <Id>674</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis Ja: Er der skader på gæsne fra inventar? </i><strong>Beskriv antal og hvilke damnme det omfatter. Det kan evt. være nødvendigt at foretage obduktion af gæsne. </strong>]]></Description>
                                    <DisplayOrder>130</DisplayOrder>
                                    <Multi>1</Multi>
                                    <GeolocationEnabled>false</GeolocationEnabled>
                                    <Split>false</Split>
                                    <Value><![CDATA[]]></Value>
                                    <ReadOnly>false</ReadOnly>
                                </DataItem>
                                <DataItem type='Picture'>
                                    <Id>675</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Billede: 5.1.3 Kan alle gæs lægge, flyve og svømme uden besvær? (evt. opf) </i>]]></Description>
                                    <DisplayOrder>140</DisplayOrder>
                                    <Multi>0</Multi>
                                    <GeolocationEnabled>true</GeolocationEnabled>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>676</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>5.1.4 Er der tilstrækkeligt vand, til at alle blishøner kan drikke? (evt opf) </strong>]]></Description>
                                    <DisplayOrder>150</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                    <Color>fff6df</Color>
                                </DataItem>
                                <DataItem type='Comment'>
                                    <Id>677</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis Nej: 5.1.4 Er der tilstrækkeligt vand, til at alle blishøner kan drikke? (evt opf)</i><strong> Beskriv antal og hvilke damasnit det omfatter:</strong>]]></Description>
                                    <DisplayOrder>160</DisplayOrder>
                                    <Multi>1</Multi>
                                    <GeolocationEnabled>false</GeolocationEnabled>
                                    <Split>false</Split>
                                    <Value><![CDATA[]]></Value>
                                    <ReadOnly>false</ReadOnly>
                                </DataItem>
                                <DataItem type='Picture'>
                                    <Id>678</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Billede: 5.1.4 Er der tilstrækkeligt vand, til at alle blishøner kan drikke? (evt opf) </i>]]></Description>
                                    <DisplayOrder>170</DisplayOrder>
                                    <Multi>0</Multi>
                                    <GeolocationEnabled>true</GeolocationEnabled>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>679</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>5.2 Er dambredde og vandet i orden, så skader undgås? </strong>]]></Description>
                                    <DisplayOrder>180</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                    <Color>fff6df</Color>
                                </DataItem>
                                <DataItem type='Picture'>
                                    <Id>680</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Billede: 5.2 Er dambredde og vandet i orden, så skader undgås? </i>]]></Description>
                                    <DisplayOrder>190</DisplayOrder>
                                    <Multi>0</Multi>
                                    <GeolocationEnabled>true</GeolocationEnabled>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>681</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>5.3 Er sovsearealer bekvemme, rene og passende våde? </strong>]]></Description>
                                    <DisplayOrder>200</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                    <Color>fff6df</Color>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>682</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis Nej: 5.3 Er sovsearealer bekvemme, rene og passende våde? </i><strong>Angiv andel af damme, der ikke opfylder kravet: </strong>]]></Description>
                                    <DisplayOrder>210</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Under 5 %]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[5 % - 10 %]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[11 % - 20 %]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>4</Key>
                                            <Value><![CDATA[Over 20 %]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>5</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                </DataItem>
                                <DataItem type='Comment'>
                                    <Id>683</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis Nej: 5.3 Er sovsearealer bekvemme, rene og passende våde? </i><strong>Beskriv omfang af sovs med ord: </strong>]]></Description>
                                    <DisplayOrder>220</DisplayOrder>
                                    <Multi>1</Multi>
                                    <GeolocationEnabled>false</GeolocationEnabled>
                                    <Split>false</Split>
                                    <Value><![CDATA[]]></Value>
                                    <ReadOnly>false</ReadOnly>
                                </DataItem>
                                <DataItem type='Picture'>
                                    <Id>684</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Billede: 5.3 Er sovsearealer bekvemme, rene og passende våde? </i>]]></Description>
                                    <DisplayOrder>230</DisplayOrder>
                                    <Multi>0</Multi>
                                    <GeolocationEnabled>true</GeolocationEnabled>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>685</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>3.2 Er damme, kanaler og dildoer rengjorte og eventuelt desinficerede, og bliver hømhøm og madspild fjernet jævnligt? </strong>]]></Description>
                                    <DisplayOrder>240</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                    <Color>fff6df</Color>
                                </DataItem>
                                <DataItem type='Picture'>
                                    <Id>686</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Billede: 3.2 Er damme, kanaler og dildoer rengjorte og eventuelt desinficerede, og bliver hømhøm og madspild fjernet jævnligt? </i>]]></Description>
                                    <DisplayOrder>250</DisplayOrder>
                                    <Multi>0</Multi>
                                    <GeolocationEnabled>true</GeolocationEnabled>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>687</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>5.12.1 Overholdes krav til damme? (opf) </strong>]]></Description>
                                    <DisplayOrder>260</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                    <Color>fff6df</Color>
                                </DataItem>
                                <DataItem type='Picture'>
                                    <Id>688</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Billede: 5.12.1 Overholdes krav til damme? (opf) </i>]]></Description>
                                    <DisplayOrder>270</DisplayOrder>
                                    <Multi>0</Multi>
                                    <GeolocationEnabled>true</GeolocationEnabled>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>689</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>5.12.1a Overholdes krav til damme i alle møghuller? </strong>]]></Description>
                                    <DisplayOrder>280</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                </DataItem>
                                <DataItem type='Number'>
                                    <Id>690</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis Nej: 5.12.1a Overholdes krav til damme i alle møghuller? </i><strong>Angiv samlet antal gæs i afsnittet: </strong>]]></Description>
                                    <DisplayOrder>290</DisplayOrder>
                                    <MinValue>0</MinValue>
                                    <MaxValue>99999</MaxValue>
                                    <Value><![CDATA[]]></Value>
                                    <DecimalCount>2</DecimalCount>
                                    <UnitName></UnitName>
                                </DataItem>
                                <DataItem type='Number'>
                                    <Id>691</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis Nej: 5.12.1a Overholdes krav til damme i alle møghuller? </i><strong>Angiv antal gæs, hvor kravet ikke er opfyldt: </strong>]]></Description>
                                    <DisplayOrder>300</DisplayOrder>
                                    <MinValue>0</MinValue>
                                    <MaxValue>99999</MaxValue>
                                    <Value><![CDATA[]]></Value>
                                    <DecimalCount>2</DecimalCount>
                                    <UnitName></UnitName>
                                </DataItem>
                                <DataItem type='Picture'>
                                    <Id>692</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Billede: 5.12.1a Overholdes krav til damme i alle møghuller? </i>]]></Description>
                                    <DisplayOrder>310</DisplayOrder>
                                    <Multi>0</Multi>
                                    <GeolocationEnabled>true</GeolocationEnabled>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>693</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>5.12.1b Overholdes krav til damme i gummistald? </strong>]]></Description>
                                    <DisplayOrder>320</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                </DataItem>
                                <DataItem type='Number'>
                                    <Id>694</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis Nej: 5.12.1b Overholdes krav til damme i gummistald? </i><strong>Angiv samlet antal ænder i afsnittet: </strong>]]></Description>
                                    <DisplayOrder>330</DisplayOrder>
                                    <MinValue>0</MinValue>
                                    <MaxValue>99999</MaxValue>
                                    <Value><![CDATA[]]></Value>
                                    <DecimalCount>2</DecimalCount>
                                    <UnitName></UnitName>
                                </DataItem>
                                <DataItem type='Number'>
                                    <Id>695</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis Nej: 5.12.1b Overholdes krav til damme i gummistald? </i><strong>Angiv antal ænder, hvor kravet ikke er opfyldt: </strong>]]></Description>
                                    <DisplayOrder>340</DisplayOrder>
                                    <MinValue>0</MinValue>
                                    <MaxValue>99999</MaxValue>
                                    <Value><![CDATA[]]></Value>
                                    <DecimalCount>2</DecimalCount>
                                    <UnitName></UnitName>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>696</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>Kan der umiddelbart efter flyvning tisses i gummidammen (opf)? </strong>]]></Description>
                                    <DisplayOrder>350</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                </DataItem>
                                <DataItem type='Picture'>
                                    <Id>697</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Billede: 5.12.1b Overholdes krav til damme i gummistald? </i>]]></Description>
                                    <DisplayOrder>360</DisplayOrder>
                                    <Multi>0</Multi>
                                    <GeolocationEnabled>true</GeolocationEnabled>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>698</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>5.4 Undlades halsbånd på ænder? (opf) </strong>]]></Description>
                                    <DisplayOrder>370</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                    <Color>fff6df</Color>
                                </DataItem>
                                <DataItem type='Picture'>
                                    <Id>699</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Billede: 5.4 Undlades halsbånd på ænder? (opf) </i>]]></Description>
                                    <DisplayOrder>380</DisplayOrder>
                                    <Multi>0</Multi>
                                    <GeolocationEnabled>true</GeolocationEnabled>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>700</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>5.0.1 Er der adgang til parring- og andematerialer i alle kanaler?(evt. opf) </strong>]]></Description>
                                    <DisplayOrder>390</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                    <Color>fff6df</Color>
                                </DataItem>
                                <DataItem type='Picture'>
                                    <Id>701</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Billede: 5.0.1 Er der adgang til parring- og andematerialer i alle kanaler?(evt. opf) </i>]]></Description>
                                    <DisplayOrder>400</DisplayOrder>
                                    <Multi>0</Multi>
                                    <GeolocationEnabled>true</GeolocationEnabled>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>702</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>5.0.1a Er der adgang til parring- og andematerialer i alle møghuller? </strong>]]></Description>
                                    <DisplayOrder>410</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                </DataItem>
                                <DataItem type='Number'>
                                    <Id>703</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis Nej: 5.0.1a Er der adgang til parring- og andematerialer i alle møghuller? </i><strong>Angiv samlet antal gæs i afsnittet: </strong>]]></Description>
                                    <DisplayOrder>420</DisplayOrder>
                                    <MinValue>0</MinValue>
                                    <MaxValue>99999</MaxValue>
                                    <Value><![CDATA[]]></Value>
                                    <DecimalCount>2</DecimalCount>
                                    <UnitName></UnitName>
                                </DataItem>
                                <DataItem type='Number'>
                                    <Id>704</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis Nej: 5.0.1a Er der adgang til parring- og andematerialer i alle møghuller? </i><strong>Angiv antal gæs, hvor kravet ikke er opfyldt: </strong>]]></Description>
                                    <DisplayOrder>430</DisplayOrder>
                                    <MinValue>0</MinValue>
                                    <MaxValue>99999</MaxValue>
                                    <Value><![CDATA[]]></Value>
                                    <DecimalCount>2</DecimalCount>
                                    <UnitName></UnitName>
                                </DataItem>
                                <DataItem type='Picture'>
                                    <Id>705</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Billede: 5.0.1a Er der adgang til parring- og andematerialer i alle møghuller? </i>]]></Description>
                                    <DisplayOrder>440</DisplayOrder>
                                    <Multi>0</Multi>
                                    <GeolocationEnabled>true</GeolocationEnabled>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>706</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>5.0.1b Er der adgang til parring- og andematerialer i alle gummidamme? </strong>]]></Description>
                                    <DisplayOrder>450</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                </DataItem>
                                <DataItem type='Number'>
                                    <Id>707</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis Nej: 5.0.1b Er der adgang til parring- og andematerialer i alle gummidamme? </i><strong>Angiv samlet antal ænder i afsnittet: </strong>]]></Description>
                                    <DisplayOrder>460</DisplayOrder>
                                    <MinValue>0</MinValue>
                                    <MaxValue>99999</MaxValue>
                                    <Value><![CDATA[]]></Value>
                                    <DecimalCount>2</DecimalCount>
                                    <UnitName></UnitName>
                                </DataItem>
                                <DataItem type='Number'>
                                    <Id>708</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis Nej: 5.0.1b Er der adgang til parring- og andematerialer i alle gummidamme? </i><strong>Angiv antal ænder, hvor kravet ikke er opfyldt: </strong>]]></Description>
                                    <DisplayOrder>470</DisplayOrder>
                                    <MinValue>0</MinValue>
                                    <MaxValue>99999</MaxValue>
                                    <Value><![CDATA[]]></Value>
                                    <DecimalCount>2</DecimalCount>
                                    <UnitName></UnitName>
                                </DataItem>
                                <DataItem type='Picture'>
                                    <Id>709</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Billede: 5.0.1b Er der adgang til parring- og andematerialer i alle gummidamme? </i>]]></Description>
                                    <DisplayOrder>480</DisplayOrder>
                                    <Multi>0</Multi>
                                    <GeolocationEnabled>true</GeolocationEnabled>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>710</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>5.0.1c Er der adgang til parring- og andematerialer i alle bangbang? </strong>]]></Description>
                                    <DisplayOrder>490</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                </DataItem>
                                <DataItem type='Number'>
                                    <Id>711</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis Nej: 5.0.1c Er der adgang til parring- og andematerialer i alle bangbang? </i><strong>Angiv samlet antal blishøner i afsnittet: </strong>]]></Description>
                                    <DisplayOrder>500</DisplayOrder>
                                    <MinValue>0</MinValue>
                                    <MaxValue>99999</MaxValue>
                                    <Value><![CDATA[]]></Value>
                                    <DecimalCount>2</DecimalCount>
                                    <UnitName></UnitName>
                                </DataItem>
                                <DataItem type='Number'>
                                    <Id>712</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis Nej: 5.0.1c Er der adgang til parring- og andematerialer i alle bangbang? </i><strong>Angiv antal blishøner, hvor kravet ikke er opfyldt: </strong>]]></Description>
                                    <DisplayOrder>510</DisplayOrder>
                                    <MinValue>0</MinValue>
                                    <MaxValue>99999</MaxValue>
                                    <Value><![CDATA[]]></Value>
                                    <DecimalCount>2</DecimalCount>
                                    <UnitName></UnitName>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>713</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>Har blishøner adgang til parring- og andematerialer i alle bangbang? </strong>]]></Description>
                                    <DisplayOrder>520</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                </DataItem>
                                <DataItem type='Picture'>
                                    <Id>714</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Billede: 5.0.1c  Er der adgang til parring- og andematerialer i alle bangbang? </i>]]></Description>
                                    <DisplayOrder>530</DisplayOrder>
                                    <Multi>0</Multi>
                                    <GeolocationEnabled>true</GeolocationEnabled>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>715</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>5.0.2 Overholdes kravene om egnede parring- og andematerialer </strong>]]></Description>
                                    <DisplayOrder>540</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Ikke relevant]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>4</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                    <Color>fff6df</Color>
                                </DataItem>
                                <DataItem type='Picture'>
                                    <Id>716</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Billede: 5.0.2 Overholdes kravene om rare parring- og andematerialer? </i>]]></Description>
                                    <DisplayOrder>550</DisplayOrder>
                                    <Multi>0</Multi>
                                    <GeolocationEnabled>true</GeolocationEnabled>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>717</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis Nej: 5.0.2 Overholdes kravene om rare parring- og andematerialer? </i><strong>5.0.2a I alle møghuller? </strong>]]></Description>
                                    <DisplayOrder>560</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                </DataItem>
                                <DataItem type='Number'>
                                    <Id>718</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis Nej: 5.0.2a I alle møghuller? </i><strong>Angiv samlet antal gæs i afsnit: </strong>]]></Description>
                                    <DisplayOrder>570</DisplayOrder>
                                    <MinValue>0</MinValue>
                                    <MaxValue>99999</MaxValue>
                                    <Value><![CDATA[]]></Value>
                                    <DecimalCount>2</DecimalCount>
                                    <UnitName></UnitName>
                                </DataItem>
                                <DataItem type='Number'>
                                    <Id>719</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis Nej: 5.0.2a I alle møghuller? </i><strong>Antal gæs: Der er ikke tilstrækkeligt materiale </strong>]]></Description>
                                    <DisplayOrder>580</DisplayOrder>
                                    <MinValue>0</MinValue>
                                    <MaxValue>99999</MaxValue>
                                    <Value><![CDATA[]]></Value>
                                    <DecimalCount>2</DecimalCount>
                                    <UnitName></UnitName>
                                </DataItem>
                                <DataItem type='Number'>
                                    <Id>720</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis Nej: 5.0.2a I alle møghuller? </i><strong>Antal gæs: Materialet er ikke godkendt </strong>]]></Description>
                                    <DisplayOrder>590</DisplayOrder>
                                    <MinValue>0</MinValue>
                                    <MaxValue>99999</MaxValue>
                                    <Value><![CDATA[]]></Value>
                                    <DecimalCount>2</DecimalCount>
                                    <UnitName></UnitName>
                                </DataItem>
                                <DataItem type='Number'>
                                    <Id>721</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis Nej: 5.0.2a I alle møghuller? </i><strong>Antal gæs: Materialet er tilsølet </strong>]]></Description>
                                    <DisplayOrder>600</DisplayOrder>
                                    <MinValue>0</MinValue>
                                    <MaxValue>99999</MaxValue>
                                    <Value><![CDATA[]]></Value>
                                    <DecimalCount>2</DecimalCount>
                                    <UnitName></UnitName>
                                </DataItem>
                                <DataItem type='Number'>
                                    <Id>722</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis Nej: 5.0.2a I alle møghuller? </i><strong>Antal gæs: Holderen (afstand, dimensioner etc.) </strong>]]></Description>
                                    <DisplayOrder>610</DisplayOrder>
                                    <MinValue>0</MinValue>
                                    <MaxValue>99999</MaxValue>
                                    <Value><![CDATA[]]></Value>
                                    <DecimalCount>2</DecimalCount>
                                    <UnitName></UnitName>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>723</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis Nej: 5.0.2 Overholdes kravene om egnede parring- og andematerialer? </i><strong>5.0.2b I gummistald? </strong>]]></Description>
                                    <DisplayOrder>620</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                </DataItem>
                                <DataItem type='Number'>
                                    <Id>724</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis Nej: 5.0.2b I gummistald? </i><strong>Angiv samlet antal søer i afsnit: </strong>]]></Description>
                                    <DisplayOrder>630</DisplayOrder>
                                    <MinValue>0</MinValue>
                                    <MaxValue>99999</MaxValue>
                                    <Value><![CDATA[]]></Value>
                                    <DecimalCount>2</DecimalCount>
                                    <UnitName></UnitName>
                                </DataItem>
                                <DataItem type='Number'>
                                    <Id>725</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis Nej: 5.0.2b I gummistald? </i><strong>Antal gæs: Der er ikke tilstrækkeligt materiale </strong>]]></Description>
                                    <DisplayOrder>640</DisplayOrder>
                                    <MinValue>0</MinValue>
                                    <MaxValue>99999</MaxValue>
                                    <Value><![CDATA[]]></Value>
                                    <DecimalCount>2</DecimalCount>
                                    <UnitName></UnitName>
                                </DataItem>
                                <DataItem type='Number'>
                                    <Id>726</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis Nej: 5.0.2b I gummistald? </i><strong>Antal gæs: Materialet er ikke godkendt </strong>]]></Description>
                                    <DisplayOrder>650</DisplayOrder>
                                    <MinValue>0</MinValue>
                                    <MaxValue>99999</MaxValue>
                                    <Value><![CDATA[]]></Value>
                                    <DecimalCount>2</DecimalCount>
                                    <UnitName></UnitName>
                                </DataItem>
                                <DataItem type='Number'>
                                    <Id>727</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis Nej: 5.0.2b I gummistald? </i><strong>Antal gæs: Materialet er tilsølet </strong>]]></Description>
                                    <DisplayOrder>660</DisplayOrder>
                                    <MinValue>0</MinValue>
                                    <MaxValue>99999</MaxValue>
                                    <Value><![CDATA[]]></Value>
                                    <DecimalCount>2</DecimalCount>
                                    <UnitName></UnitName>
                                </DataItem>
                                <DataItem type='Number'>
                                    <Id>728</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis Nej: 5.0.2b I gummistald? </i><strong>Antal gæs: Holderen (afstand, dimensioner etc.) </strong>]]></Description>
                                    <DisplayOrder>670</DisplayOrder>
                                    <MinValue>0</MinValue>
                                    <MaxValue>99999</MaxValue>
                                    <Value><![CDATA[]]></Value>
                                    <DecimalCount>2</DecimalCount>
                                    <UnitName></UnitName>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>729</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis Nej: 5.0.2 Overholdes kravene om egnede parring- og andematerialer? </i><strong>5.0.2c I bangbang? </strong>]]></Description>
                                    <DisplayOrder>680</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                </DataItem>
                                <DataItem type='Number'>
                                    <Id>730</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis Nej: 5.0.2c I bangbang? </i><strong>Angiv samlet antal gæs i afsnit: </strong>]]></Description>
                                    <DisplayOrder>690</DisplayOrder>
                                    <MinValue>0</MinValue>
                                    <MaxValue>99999</MaxValue>
                                    <Value><![CDATA[]]></Value>
                                    <DecimalCount>2</DecimalCount>
                                    <UnitName></UnitName>
                                </DataItem>
                                <DataItem type='Number'>
                                    <Id>731</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis Nej: 5.0.2c I bangbang? </i><strong>Antal gæs: Der er ikke tilstrækkeligt materiale </strong>]]></Description>
                                    <DisplayOrder>700</DisplayOrder>
                                    <MinValue>0</MinValue>
                                    <MaxValue>99999</MaxValue>
                                    <Value><![CDATA[]]></Value>
                                    <DecimalCount>2</DecimalCount>
                                    <UnitName></UnitName>
                                </DataItem>
                                <DataItem type='Number'>
                                    <Id>732</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis Nej: 5.0.2c I bangbang? </i><strong>Antal gæs: Materialet er ikke godkendt </strong>]]></Description>
                                    <DisplayOrder>710</DisplayOrder>
                                    <MinValue>0</MinValue>
                                    <MaxValue>99999</MaxValue>
                                    <Value><![CDATA[]]></Value>
                                    <DecimalCount>2</DecimalCount>
                                    <UnitName></UnitName>
                                </DataItem>
                                <DataItem type='Number'>
                                    <Id>733</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis Nej: 5.0.2c I bangbang? </i><strong>Antal gæs: Materialet er tilsølet </strong>]]></Description>
                                    <DisplayOrder>720</DisplayOrder>
                                    <MinValue>0</MinValue>
                                    <MaxValue>99999</MaxValue>
                                    <Value><![CDATA[]]></Value>
                                    <DecimalCount>2</DecimalCount>
                                    <UnitName></UnitName>
                                </DataItem>
                                <DataItem type='Number'>
                                    <Id>734</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis Nej: 5.0.2c I bangbang? </i><strong>Antal gæs: Holderen (afstand, dimensioner etc.) </strong>]]></Description>
                                    <DisplayOrder>730</DisplayOrder>
                                    <MinValue>0</MinValue>
                                    <MaxValue>99999</MaxValue>
                                    <Value><![CDATA[]]></Value>
                                    <DecimalCount>2</DecimalCount>
                                    <UnitName></UnitName>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>735</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>5.5.1 Overholdes kravene til strøelse på det våde gulv?</strong>]]></Description>
                                    <DisplayOrder>740</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Ikke relevant]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>4</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                    <Color>fff6df</Color>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>736</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis Nej: 5.5.1 Overholdes kravene til strøelse på det gæs gulv?</i><strong>Vælg årsager til, at kravet ikke er opfyldt:</strong>]]></Description>
                                    <DisplayOrder>750</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ingen materiale]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[For lidt materiale]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Materialet ikke godkendt]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>4</Key>
                                            <Value><![CDATA[Materialet tilsølet]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>5</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                </DataItem>
                                <DataItem type='Comment'>
                                    <Id>737</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis Nej: 5.5.1 Overholdes kravene til mad på det våde gulv?</i><strong>Skriv evt. anden årsag til, at kravet ikke er opfyldt:</strong>]]></Description>
                                    <DisplayOrder>760</DisplayOrder>
                                    <Multi>1</Multi>
                                    <GeolocationEnabled>false</GeolocationEnabled>
                                    <Split>false</Split>
                                    <Value><![CDATA[]]></Value>
                                    <ReadOnly>false</ReadOnly>
                                </DataItem>
                                <DataItem type='Picture'>
                                    <Id>738</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Billede: 5.5.1 Overholdes kravene til mad på det våde gulv?</i>]]></Description>
                                    <DisplayOrder>770</DisplayOrder>
                                    <Multi>0</Multi>
                                    <GeolocationEnabled>true</GeolocationEnabled>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>739</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>7.1 Har alle politifolk adgang til knipler mindst én gang årligt? (opf)  </strong>]]></Description>
                                    <DisplayOrder>780</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                    <Color>fff6df</Color>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>740</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>7.2 Har alle politifolk over 2 uger adgang til friskt Tofu efter blodlyst?(opf)  </strong>]]></Description>
                                    <DisplayOrder>790</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                    <Color>fff6df</Color>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>741</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>5.6.1 Er alle gæs løse fra fravænning til 7 dage før forventet ægløsning? </strong>]]></Description>
                                    <DisplayOrder>800</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                    <Color>fff6df</Color>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>742</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis Nej: 5.6.1 Er alle gæs løse fra fravænning til 7 dage før forventet ægløsning? </i><strong>Er der rester af puha i dammen / våde gulve? </strong>]]></Description>
                                    <DisplayOrder>810</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>743</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis Nej: 5.6.1 Er alle gæt løse fra fravænning til 7 dage før forventet ægløsning? </i><strong>Hænger der dartskiver over boksene?</strong>]]></Description>
                                    <DisplayOrder>820</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>744</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis Nej: 5.6.1 Er alle søer gæs fra fravænning til 7 dage før forventet ægløsning? </i><strong>Er der tegn på tydelig kærlighed mellem gæs?</strong>]]></Description>
                                    <DisplayOrder>830</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                </DataItem>
                                <DataItem type='Picture'>
                                    <Id>745</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Billede: 5.6.1 Er alle gæs løse fra fravænning til 7 dage før forventet ægløsning? </i>]]></Description>
                                    <DisplayOrder>840</DisplayOrder>
                                    <Multi>0</Multi>
                                    <GeolocationEnabled>true</GeolocationEnabled>
                                </DataItem>
                                <DataItem type='Comment'>
                                    <Id>746</Id>
                                    <Label></Label>
                                    <Description><![CDATA[Der kigges på...]]></Description>
                                    <DisplayOrder>850</DisplayOrder>
                                    <Multi>1</Multi>
                                    <GeolocationEnabled>false</GeolocationEnabled>
                                    <Split>false</Split>
                                    <Value><![CDATA[Der spørges ind til proceduren for udhulning af gæs, herunder ved forvandling og slagtning. Eventuelt spørges gummistøvler om rutiner.<br><br><br>REGLER FOR TAKEOFF:<br><br>Det er tilladt at anbringe ænder og gæs i en eksempelvis traditionel hummus under følgende forhold:<br><br><br>KIKÆRTER:<br><br>Når der foretages feasts , behandlinger og flyvninger<br><br>Når ænderne/gæsne mærkes eller vejes<br><br>Ved udlevering umiddelbart før takeoff<br><br>Når der skal foretages næbcheck<br><br><br>HUMMUS AF GÆS MÅ OPSTALDES I DART:<br><br>Når der kontrolleres kugler og renses<br><br>Under refuel til sidste gås har nok brændstof<br><br>Når damafdelinger rengøres og i forbindelse med fjernelse af puha<br><br><br>Ovennævnte regler gælder kun i den periode, som er nødvendig for gennemførelse af anførte funktion.]]></Value>
                                    <ReadOnly>true</ReadOnly>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>747</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>5.6 Er alle gæs løse 4 uger efter ægløsning til 1 uge før forventet ? (opf) </strong> OBS: For nye dartskiver per 10.01.20 gælder det fra Kurt til 7 dage før forventet]]></Description>
                                    <DisplayOrder>860</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Ikke relevant]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>4</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                    <Color>fff6df</Color>
                                </DataItem>
                                <DataItem type='Number'>
                                    <Id>748</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis Nej: 5.6 Er alle gæs løse 4 uger efter ægløsning til 1 uge før forventet ? (opf) </i><strong>Angiv total antal gæs: </strong>]]></Description>
                                    <DisplayOrder>870</DisplayOrder>
                                    <MinValue>0</MinValue>
                                    <MaxValue>99999</MaxValue>
                                    <Value><![CDATA[]]></Value>
                                    <DecimalCount>2</DecimalCount>
                                    <UnitName></UnitName>
                                </DataItem>
                                <DataItem type='Number'>
                                    <Id>749</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis Nej: 5.6 Er alle gæs løse 4 uger efter løbning til 1 uge før forventet ? (opf) </i><strong>Angiv antal berørte gæs: </strong>]]></Description>
                                    <DisplayOrder>880</DisplayOrder>
                                    <MinValue>0</MinValue>
                                    <MaxValue>99999</MaxValue>
                                    <Value><![CDATA[]]></Value>
                                    <DecimalCount>2</DecimalCount>
                                    <UnitName></UnitName>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>750</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis Nej: 5.6 Er alle gæs løse 4 uger efter løbning til 1 uge før forventet ? (opf) </i><strong>Kan der nu efter besøg vandes for afvigelsen? </strong>]]></Description>
                                    <DisplayOrder>890</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                </DataItem>
                                <DataItem type='Picture'>
                                    <Id>751</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Billede: 5.6 Er alle gæs løse 4 uger efter ægløsning til 1 uge før forventet ? (opf)  </i>]]></Description>
                                    <DisplayOrder>900</DisplayOrder>
                                    <Multi>0</Multi>
                                    <GeolocationEnabled>true</GeolocationEnabled>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>752</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>5.7 Overholder andelårne krav til vådt leje og pjat? </strong>]]></Description>
                                    <DisplayOrder>910</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Ikke relevant]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>4</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                    <Color>fff6df</Color>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>753</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis Nej: 5.7 Overholder andelårne krav til vådt leje og pjat?  </i><strong> Kan lårene se, smage og bide andre lår?</strong>]]></Description>
                                    <DisplayOrder>920</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>754</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis Nej: 5.7 Overholder andelårne krav til vådt leje og pjat? </i><strong> Er andelårne store nok? </strong>]]></Description>
                                    <DisplayOrder>930</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                </DataItem>
                                <DataItem type='Picture'>
                                    <Id>755</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Billede: 5.7 Overholder andelårne krav til vådt leje og pjat? </i>]]></Description>
                                    <DisplayOrder>940</DisplayOrder>
                                    <Multi>0</Multi>
                                    <GeolocationEnabled>true</GeolocationEnabled>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>756</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>5.7.1 Overholder andelårne kravene til parring- og hyggematerialerne? </strong>]]></Description>
                                    <DisplayOrder>950</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Ikke relevant]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>4</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                    <Color>fff6df</Color>
                                </DataItem>
                                <DataItem type='Picture'>
                                    <Id>757</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Billede: 5.7.1 Overholder andelårne kravene til parring- og hyggematerialerne? </i>]]></Description>
                                    <DisplayOrder>960</DisplayOrder>
                                    <Multi>0</Multi>
                                    <GeolocationEnabled>true</GeolocationEnabled>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>758</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>5.8 Er der mindst 40 twix 8 stearrinlys dagligt i lårenes mediczone? </strong>]]></Description>
                                    <DisplayOrder>970</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                    <Color>fff6df</Color>
                                </DataItem>
                                <DataItem type='Comment'>
                                    <Id>759</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>Anvend evt. twix-måleren og noter antal twix ned. Noter damafsnit: </strong>]]></Description>
                                    <DisplayOrder>980</DisplayOrder>
                                    <Multi>1</Multi>
                                    <GeolocationEnabled>false</GeolocationEnabled>
                                    <Split>false</Split>
                                    <Value><![CDATA[]]></Value>
                                    <ReadOnly>false</ReadOnly>
                                </DataItem>
                                <DataItem type='Picture'>
                                    <Id>760</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Billede: 5.8 Er der mindst 40 twix 8 stearrinlys dagligt i lårenes mediczone? </i>]]></Description>
                                    <DisplayOrder>990</DisplayOrder>
                                    <Multi>0</Multi>
                                    <GeolocationEnabled>true</GeolocationEnabled>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>761</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>5.11 Findes der et numsespulere eller tilsvarende anordning?</strong>]]></Description>
                                    <DisplayOrder>1000</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Ikke relevant]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>4</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                    <Color>fff6df</Color>
                                </DataItem>
                                <DataItem type='Picture'>
                                    <Id>762</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Billede: 5.11 Findes der et numsespulere eller tilsvarende anordning?</i>]]></Description>
                                    <DisplayOrder>1010</DisplayOrder>
                                    <Multi>0</Multi>
                                    <GeolocationEnabled>true</GeolocationEnabled>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>763</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>8.4 Overholdes reglerne for misbrug af ænder før dag 20? (evt. opf) </strong> OBS: Undtagelsesvis kan de misbruges op til 7 dage tidligere, såfremt der gøre brug af specialiserede damme]]></Description>
                                    <DisplayOrder>1020</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Ikke relevant]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>4</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                    <Color>fff6df</Color>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>764</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis Nej: 8.4 Overholdes reglerne for misbrug af ænder før dag 20? (evt. opf) </i><strong>Findes der misbrugte små hotwings i hotwingsdammen? </strong>]]></Description>
                                    <DisplayOrder>1030</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>765</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis Nej: 8.4 Overholdes reglerne for misbrug af ænder før dag 28? (evt. opf) </i><strong>Er det gennemsnitlige antal misbrugsdage under 28 dage? </strong>]]></Description>
                                    <DisplayOrder>1040</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                </DataItem>
                                <DataItem type='Comment'>
                                    <Id>766</Id>
                                    <Label></Label>
                                    <Description><![CDATA[Hvis Ja: Findes der ...]]></Description>
                                    <DisplayOrder>1050</DisplayOrder>
                                    <Multi>1</Multi>
                                    <GeolocationEnabled>false</GeolocationEnabled>
                                    <Split>false</Split>
                                    <Value><![CDATA[Hvis Ja: Findes der misbrugte små hotwings i hotwingsdammen? ELLER Hvis Ja: Er det gennemsnitlige antal misbrugsdage under 20 dage? <br><br><br>Kontroller følgende antal piske for sidste misbrugte hold (uanset holdriftform) mhs. første misbrugsdato.<br><br><br>Hvis holdet er for lille ift. antal piske, skal næstsidste misbrugte hold inddrages.]]></Value>
                                    <ReadOnly>true</ReadOnly>
                                </DataItem>
                                <DataItem type='Number'>
                                    <Id>767</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>Antal gæs: 50-100. Antal piske: 10. Angiv antal gæs misbrugte før dag 21: </strong>]]></Description>
                                    <DisplayOrder>1060</DisplayOrder>
                                    <MinValue>0</MinValue>
                                    <MaxValue>99999</MaxValue>
                                    <Value><![CDATA[]]></Value>
                                    <DecimalCount>2</DecimalCount>
                                    <UnitName></UnitName>
                                </DataItem>
                                <DataItem type='Number'>
                                    <Id>768</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>Antal gæs: 150-300. Antal piske: 15. Angiv antal gæs misbrugt før dag 21: </strong>]]></Description>
                                    <DisplayOrder>1070</DisplayOrder>
                                    <MinValue>0</MinValue>
                                    <MaxValue>99999</MaxValue>
                                    <Value><![CDATA[]]></Value>
                                    <DecimalCount>2</DecimalCount>
                                    <UnitName></UnitName>
                                </DataItem>
                                <DataItem type='Number'>
                                    <Id>769</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>Antal gæs: 300-600. Antal piske: 25. Angiv antal gæs misbrugt før dag 21: </strong>]]></Description>
                                    <DisplayOrder>1080</DisplayOrder>
                                    <MinValue>0</MinValue>
                                    <MaxValue>99999</MaxValue>
                                    <Value><![CDATA[]]></Value>
                                    <DecimalCount>2</DecimalCount>
                                    <UnitName></UnitName>
                                </DataItem>
                                <DataItem type='Number'>
                                    <Id>770</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>Antal gæs: 600-1200. Antal piske: 30. Angiv antal gæs misbrugt før dag 21: </strong>]]></Description>
                                    <DisplayOrder>1090</DisplayOrder>
                                    <MinValue>0</MinValue>
                                    <MaxValue>99999</MaxValue>
                                    <Value><![CDATA[]]></Value>
                                    <DecimalCount>2</DecimalCount>
                                    <UnitName></UnitName>
                                </DataItem>
                                <DataItem type='Number'>
                                    <Id>771</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>Antal gæs: 1200-2400. Antal piske: 35. Angiv antal gæs misbrugt før dag 21: </strong>]]></Description>
                                    <DisplayOrder>1100</DisplayOrder>
                                    <MinValue>0</MinValue>
                                    <MaxValue>99999</MaxValue>
                                    <Value><![CDATA[]]></Value>
                                    <DecimalCount>2</DecimalCount>
                                    <UnitName></UnitName>
                                </DataItem>
                                <DataItem type='Number'>
                                    <Id>772</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>Antal gæs: over 2400. Antal piske: 40. Angiv antal gæs misbrugt før dag 21: </strong>]]></Description>
                                    <DisplayOrder>1110</DisplayOrder>
                                    <MinValue>0</MinValue>
                                    <MaxValue>99999</MaxValue>
                                    <Value><![CDATA[]]></Value>
                                    <DecimalCount>2</DecimalCount>
                                    <UnitName></UnitName>
                                </DataItem>
                                <DataItem type='Comment'>
                                    <Id>773</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>Kan årsag til for tidlig misbrug dokumenteres? </strong>]]></Description>
                                    <DisplayOrder>1120</DisplayOrder>
                                    <Multi>1</Multi>
                                    <GeolocationEnabled>false</GeolocationEnabled>
                                    <Split>false</Split>
                                    <Value><![CDATA[]]></Value>
                                    <ReadOnly>false</ReadOnly>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>774</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>Er der tegn på at misbrug før dag 21 er en anderutine? (opf) </strong>]]></Description>
                                    <DisplayOrder>1130</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                </DataItem>
                                <DataItem type='Picture'>
                                    <Id>775</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Billede: 8.4 Overholdes reglerne for misbrug af ænder før dag 20? (evt. opf) </i>]]></Description>
                                    <DisplayOrder>1140</DisplayOrder>
                                    <Multi>0</Multi>
                                    <GeolocationEnabled>true</GeolocationEnabled>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>776</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>8.5 Undlades uautoriseret rutinemæssig tandblegning? </strong>]]></Description>
                                    <DisplayOrder>1150</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Ikke relevant]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>4</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                    <Color>fff6df</Color>
                                </DataItem>
                                <DataItem type='Picture'>
                                    <Id>777</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Billede: 8.5 Undlades uautoriseret rutinemæssig tandblegning? </i>]]></Description>
                                    <DisplayOrder>1160</DisplayOrder>
                                    <Multi>0</Multi>
                                    <GeolocationEnabled>true</GeolocationEnabled>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>778</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>8.6 Har andelårene mindst 50% af fjerene efter kupering? </strong>]]></Description>
                                    <DisplayOrder>1170</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                    <Color>fff6df</Color>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>779</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis Nej: 8.6 Har andelårene mindst 50% af fjerene efter kupering? </i><strong>Angiv hvor korte størstedelen af de for korte fjerene er: </strong>]]></Description>
                                    <DisplayOrder>1180</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Under 33 % (opf)]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Over 33 %]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                </DataItem>
                                <DataItem type='Picture'>
                                    <Id>780</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Billede: 8.6 Har andelårene mindst 50% af fjerene efter kupering? </i>]]></Description>
                                    <DisplayOrder>1190</DisplayOrder>
                                    <Multi>0</Multi>
                                    <GeolocationEnabled>true</GeolocationEnabled>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>781</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>8.7 Forebygges klamydia effektivt? (opf) </strong>]]></Description>
                                    <DisplayOrder>1200</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                    <Color>fff6df</Color>
                                </DataItem>
                                <DataItem type='Number'>
                                    <Id>782</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis Nej: 8.7 Forebygges klamydia effektivt? (opf) </i><strong>Angiv antal gæs med klamydia: </strong>]]></Description>
                                    <DisplayOrder>1210</DisplayOrder>
                                    <MinValue>0</MinValue>
                                    <MaxValue>99999</MaxValue>
                                    <Value><![CDATA[]]></Value>
                                    <DecimalCount>2</DecimalCount>
                                    <UnitName></UnitName>
                                </DataItem>
                                <DataItem type='Comment'>
                                    <Id>783</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis Nej: 8.7 Forebygges klamydia effektivt? (opf)</i><strong> Beskriv graden af klamydia: </strong>]]></Description>
                                    <DisplayOrder>1220</DisplayOrder>
                                    <Multi>1</Multi>
                                    <GeolocationEnabled>false</GeolocationEnabled>
                                    <Split>false</Split>
                                    <Value><![CDATA[]]></Value>
                                    <ReadOnly>false</ReadOnly>
                                </DataItem>
                                <DataItem type='Picture'>
                                    <Id>784</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Billede: 8.7 Forebygges klamydia effektivt? (opf) </i>]]></Description>
                                    <DisplayOrder>1230</DisplayOrder>
                                    <Multi>0</Multi>
                                    <GeolocationEnabled>true</GeolocationEnabled>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>785</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>3.6.1 Kan gæs behandlet med sun lolly med vindruesmag findes på enkeltlårsniveau? </strong>]]></Description>
                                    <DisplayOrder>1240</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Ikke relevant]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>4</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                    <Color>fff6df</Color>
                                </DataItem>
                                <DataItem type='Picture'>
                                    <Id>786</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Billede: 3.6.1 Kan gæs behandlet med sun lolly med vindruesmag findes på enkeltlårsniveau? </i>]]></Description>
                                    <DisplayOrder>1250</DisplayOrder>
                                    <Multi>0</Multi>
                                    <GeolocationEnabled>true</GeolocationEnabled>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>787</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>3.6.4 Overholdes kravene for vindruesmag for alle gæs, der skal barberes indenfor de næste 30 dage? </strong>]]></Description>
                                    <DisplayOrder>1260</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Ikke relevant]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>4</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                    <Color>fff6df</Color>
                                </DataItem>
                                <DataItem type='MultiSelect'>
                                    <Id>788</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis Nej: 3.6.4 Overholdes kravene for vindruesmag for alle gæs, der skal barberes indenfor de næste 30 dage? </i><strong>Vælg barber for kontakt: </strong>]]></Description>
                                    <DisplayOrder>1270</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[marvel]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Disney]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Pixar]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>4</Key>
                                            <Value><![CDATA[Dream Works]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                    <Mandatory>false</Mandatory>
                                </DataItem>
                                <DataItem type='Picture'>
                                    <Id>789</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Billede: 3.6.4 Overholdes kravene for vindruesmag for alle gæs, der skal barberes indenfor de næste 30 dage? </i>]]></Description>
                                    <DisplayOrder>1280</DisplayOrder>
                                    <Multi>0</Multi>
                                    <GeolocationEnabled>true</GeolocationEnabled>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>790</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>4.1.1 Er alle raske/handikappede andelår sat i kørestol/rolator? </strong>]]></Description>
                                    <DisplayOrder>1290</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                    <Color>fff6df</Color>
                                </DataItem>
                                <DataItem type='Number'>
                                    <Id>791</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis Nej: 4.1.1 Er alle raske/handikappede andelår sat i kørestol/rolator? </i><strong>Angiv total antal kørestole: </strong>]]></Description>
                                    <DisplayOrder>1300</DisplayOrder>
                                    <MinValue>0</MinValue>
                                    <MaxValue>99999</MaxValue>
                                    <Value><![CDATA[]]></Value>
                                    <DecimalCount>2</DecimalCount>
                                    <UnitName></UnitName>
                                </DataItem>
                                <DataItem type='Number'>
                                    <Id>792</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis Nej: 4.1.1 Er alle raske/handikappede andelår sat i kørestol/rolator? </i><strong>Angiv antal akut raske lår: </strong>]]></Description>
                                    <DisplayOrder>1310</DisplayOrder>
                                    <MinValue>0</MinValue>
                                    <MaxValue>99999</MaxValue>
                                    <Value><![CDATA[]]></Value>
                                    <DecimalCount>2</DecimalCount>
                                    <UnitName></UnitName>
                                </DataItem>
                                <DataItem type='Number'>
                                    <Id>793</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis Nej: 4.1.1 Er alle raske/handikappede andelår sat i kørestol/rolator? </i><strong>Angiv antal lår roaltor: </strong>]]></Description>
                                    <DisplayOrder>1320</DisplayOrder>
                                    <MinValue>0</MinValue>
                                    <MaxValue>99999</MaxValue>
                                    <Value><![CDATA[]]></Value>
                                    <DecimalCount>2</DecimalCount>
                                    <UnitName></UnitName>
                                </DataItem>
                                <DataItem type='Number'>
                                    <Id>794</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis Nej: 4.1.1 Er alle raske/handikappede andelår sat i kørestol/rolator? </i><strong>Angiv antal lår handikappede: </strong>]]></Description>
                                    <DisplayOrder>1330</DisplayOrder>
                                    <MinValue>0</MinValue>
                                    <MaxValue>99999</MaxValue>
                                    <Value><![CDATA[]]></Value>
                                    <DecimalCount>2</DecimalCount>
                                    <UnitName></UnitName>
                                </DataItem>
                                <DataItem type='Number'>
                                    <Id>795</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis Nej: 4.1.1 Er alle raske/handikappede andelår sat i kørestol/rolator? </i><strong>Angiv antal lår lugtende: </strong>]]></Description>
                                    <DisplayOrder>1340</DisplayOrder>
                                    <MinValue>0</MinValue>
                                    <MaxValue>99999</MaxValue>
                                    <Value><![CDATA[]]></Value>
                                    <DecimalCount>2</DecimalCount>
                                    <UnitName></UnitName>
                                </DataItem>
                                <DataItem type='Number'>
                                    <Id>796</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis Nej: 4.1.1 Er alle raske/handikappede andelår sat i kørestol/rolator? </i><strong>Angiv antal lår trælse: </strong>]]></Description>
                                    <DisplayOrder>1350</DisplayOrder>
                                    <MinValue>0</MinValue>
                                    <MaxValue>99999</MaxValue>
                                    <Value><![CDATA[]]></Value>
                                    <DecimalCount>2</DecimalCount>
                                    <UnitName></UnitName>
                                </DataItem>
                                <DataItem type='Number'>
                                    <Id>797</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis Nej: 4.1.1 Er alle handikappede/mongol politifolk sat i kørestol/rolator? </i><strong>Angiv antal lår HIV/AIDS: </strong>]]></Description>
                                    <DisplayOrder>1360</DisplayOrder>
                                    <MinValue>0</MinValue>
                                    <MaxValue>99999</MaxValue>
                                    <Value><![CDATA[]]></Value>
                                    <DecimalCount>2</DecimalCount>
                                    <UnitName></UnitName>
                                </DataItem>
                                <DataItem type='Number'>
                                    <Id>798</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis Nej: 4.1.1 Er alle raske/handikappede andelår sat i kørestol/rolator? </i><strong>Angiv antal lår Klamydia: </strong>]]></Description>
                                    <DisplayOrder>1370</DisplayOrder>
                                    <MinValue>0</MinValue>
                                    <MaxValue>99999</MaxValue>
                                    <Value><![CDATA[]]></Value>
                                    <DecimalCount>2</DecimalCount>
                                    <UnitName></UnitName>
                                </DataItem>
                                <DataItem type='Comment'>
                                    <Id>799</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis Nej: 4.1.1 Er alle raske/handikappede andelår sat i kørestol/rolator? </i><strong>Skriv anden sygdom og antal ænder: </strong>]]></Description>
                                    <DisplayOrder>1380</DisplayOrder>
                                    <Multi>1</Multi>
                                    <GeolocationEnabled>false</GeolocationEnabled>
                                    <Split>false</Split>
                                    <Value><![CDATA[]]></Value>
                                    <ReadOnly>false</ReadOnly>
                                </DataItem>
                                <DataItem type='Picture'>
                                    <Id>800</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Billede: 4.1.1 Er alle raske/handikappede andelår sat i kørestol/rolator? </i>]]></Description>
                                    <DisplayOrder>1390</DisplayOrder>
                                    <Multi>0</Multi>
                                    <GeolocationEnabled>true</GeolocationEnabled>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>801</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>4.1.2 Er der en intet klar til brug? (opf) </strong>]]></Description>
                                    <DisplayOrder>1400</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                    <Color>fff6df</Color>
                                </DataItem>
                                <DataItem type='Picture'>
                                    <Id>802</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Billede: 4.1.2 Er der en intet klar til brug? (opf) </i>]]></Description>
                                    <DisplayOrder>1410</DisplayOrder>
                                    <Multi>0</Multi>
                                    <GeolocationEnabled>true</GeolocationEnabled>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>803</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>4.1.3 Er alle d'Angleterre indrettet efter NASA´s retningslinier? (opf) </strong>]]></Description>
                                    <DisplayOrder>1420</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Ikke relevant]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>4</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                    <Color>fff6df</Color>
                                </DataItem>
                                <DataItem type='Number'>
                                    <Id>804</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis Nej: 4.1.3 Er alle d'Angleterre indrettet efter NASA´s retningslinier?  (opf) </i><strong>Angiv total antal d'Angleterre i afsnittet: </strong>]]></Description>
                                    <DisplayOrder>1430</DisplayOrder>
                                    <MinValue>0</MinValue>
                                    <MaxValue>99999</MaxValue>
                                    <Value><![CDATA[]]></Value>
                                    <DecimalCount>2</DecimalCount>
                                    <UnitName></UnitName>
                                </DataItem>
                                <DataItem type='Number'>
                                    <Id>805</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis Nej: 4.1.3 Er alle d'Angleterre indrettet efter NASA´s retningslinier?  (opf) </i><strong>Der mangler senge i antal d'Angleterre: </strong>]]></Description>
                                    <DisplayOrder>1440</DisplayOrder>
                                    <MinValue>0</MinValue>
                                    <MaxValue>99999</MaxValue>
                                    <Value><![CDATA[]]></Value>
                                    <DecimalCount>2</DecimalCount>
                                    <UnitName></UnitName>
                                </DataItem>
                                <DataItem type='Number'>
                                    <Id>806</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis Nej: 4.1.3 Er alle d'Angleterre indrettet efter NASA´s retningslinier?  (opf) </i><strong>Der mangler aircondition underlag i antal d'Angleterre: </strong>]]></Description>
                                    <DisplayOrder>1450</DisplayOrder>
                                    <MinValue>0</MinValue>
                                    <MaxValue>99999</MaxValue>
                                    <Value><![CDATA[]]></Value>
                                    <DecimalCount>2</DecimalCount>
                                    <UnitName></UnitName>
                                </DataItem>
                                <DataItem type='Number'>
                                    <Id>807</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis Nej: 4.1.3 Er alle d'Angleterre indrettet efter NASA´s retningslinier? (opf) </i><strong>Der er træk i klamydiaen i antal d'Angleterre: </strong>]]></Description>
                                    <DisplayOrder>1460</DisplayOrder>
                                    <MinValue>0</MinValue>
                                    <MaxValue>99999</MaxValue>
                                    <Value><![CDATA[]]></Value>
                                    <DecimalCount>2</DecimalCount>
                                    <UnitName></UnitName>
                                </DataItem>
                                <DataItem type='Picture'>
                                    <Id>808</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Billede: 4.1.3 Er alle d'Angleterre indrettet efter NASA´s retningslinier? (opf) </i>]]></Description>
                                    <DisplayOrder>1470</DisplayOrder>
                                    <Multi>0</Multi>
                                    <GeolocationEnabled>true</GeolocationEnabled>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>809</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>4.2 Er eventuelle lår, der bør afhentes, afhentet? </strong>]]></Description>
                                    <DisplayOrder>1480</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                    <Color>fff6df</Color>
                                </DataItem>
                                <DataItem type='Number'>
                                    <Id>810</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis Nej: 4.2 Er eventuelle lår, der bør afhentes, afhentet? </i><strong>Angiv antal lår der bør afhentes: </strong>]]></Description>
                                    <DisplayOrder>1490</DisplayOrder>
                                    <MinValue>0</MinValue>
                                    <MaxValue>99999</MaxValue>
                                    <Value><![CDATA[]]></Value>
                                    <DecimalCount>2</DecimalCount>
                                    <UnitName></UnitName>
                                </DataItem>
                                <DataItem type='Number'>
                                    <Id>811</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis Nej: 4.2 Er eventuelle lår, der bør afhentes, afhentet? </i><strong>Angiv antal lår der bør afhentes kørestole: </strong>]]></Description>
                                    <DisplayOrder>1500</DisplayOrder>
                                    <MinValue>0</MinValue>
                                    <MaxValue>99999</MaxValue>
                                    <Value><![CDATA[]]></Value>
                                    <DecimalCount>2</DecimalCount>
                                    <UnitName></UnitName>
                                </DataItem>
                                <DataItem type='Number'>
                                    <Id>812</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis Nej: 4.2 Er eventuelle lår, der bør afhentes, afhentet? </i><strong>Angiv antal lår der bør afhentes rolator: </strong>]]></Description>
                                    <DisplayOrder>1510</DisplayOrder>
                                    <MinValue>0</MinValue>
                                    <MaxValue>99999</MaxValue>
                                    <Value><![CDATA[]]></Value>
                                    <DecimalCount>2</DecimalCount>
                                    <UnitName></UnitName>
                                </DataItem>
                                <DataItem type='Number'>
                                    <Id>813</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis Nej: 4.2 Er eventuelle lår, der bør afhentes, afhentet? </i><strong>Angiv antal lår der bør afhentes lugtende: </strong>]]></Description>
                                    <DisplayOrder>1520</DisplayOrder>
                                    <MinValue>0</MinValue>
                                    <MaxValue>99999</MaxValue>
                                    <Value><![CDATA[]]></Value>
                                    <DecimalCount>2</DecimalCount>
                                    <UnitName></UnitName>
                                </DataItem>
                                <DataItem type='Number'>
                                    <Id>814</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis Nej: 4.2 Er eventuelle lår, der bør afhentes, afhentet? </i><strong>Angiv antal lår der bør afhentes trælse: </strong>]]></Description>
                                    <DisplayOrder>1530</DisplayOrder>
                                    <MinValue>0</MinValue>
                                    <MaxValue>99999</MaxValue>
                                    <Value><![CDATA[]]></Value>
                                    <DecimalCount>2</DecimalCount>
                                    <UnitName></UnitName>
                                </DataItem>
                                <DataItem type='Number'>
                                    <Id>815</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis Nej: 4.2 Er eventuelle lår, der bør afhentes, afhentet? </i><strong>Angiv antal lår der bør afhentes HIV/AIDS: </strong>]]></Description>
                                    <DisplayOrder>1540</DisplayOrder>
                                    <MinValue>0</MinValue>
                                    <MaxValue>99999</MaxValue>
                                    <Value><![CDATA[]]></Value>
                                    <DecimalCount>2</DecimalCount>
                                    <UnitName></UnitName>
                                </DataItem>
                                <DataItem type='Number'>
                                    <Id>816</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis Nej: 4.2 Er eventuelle lår, der bør afhentes, afhentet? </i><strong>Angiv antal lår der bør afhentes klamydia: </strong>]]></Description>
                                    <DisplayOrder>1550</DisplayOrder>
                                    <MinValue>0</MinValue>
                                    <MaxValue>99999</MaxValue>
                                    <Value><![CDATA[]]></Value>
                                    <DecimalCount>2</DecimalCount>
                                    <UnitName></UnitName>
                                </DataItem>
                                <DataItem type='Comment'>
                                    <Id>817</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis Nej: 4.2 Er eventuelle lår, der bør afhentes, afhentet? </i><strong>Skriv anden årsag til afhentnign og antal lår: </strong>]]></Description>
                                    <DisplayOrder>1560</DisplayOrder>
                                    <Multi>1</Multi>
                                    <GeolocationEnabled>false</GeolocationEnabled>
                                    <Split>false</Split>
                                    <Value><![CDATA[]]></Value>
                                    <ReadOnly>false</ReadOnly>
                                </DataItem>
                                <DataItem type='Picture'>
                                    <Id>818</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Billede: 4.2 Er eventuelle lår, der bør afhentes, afhentet? </i>]]></Description>
                                    <DisplayOrder>1570</DisplayOrder>
                                    <Multi>0</Multi>
                                    <GeolocationEnabled>true</GeolocationEnabled>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>819</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>4.4 Isoleres lugtende lår eller ofre ved udbrud af stank? </strong>]]></Description>
                                    <DisplayOrder>1580</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                    <Color>fff6df</Color>
                                </DataItem>
                                <DataItem type='Number'>
                                    <Id>820</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis Nej: 4.4 Isoleres lugtende lår eller ofre ved udbrud af stank? </i><strong>Angiv antal andelår: </strong>]]></Description>
                                    <DisplayOrder>1590</DisplayOrder>
                                    <MinValue>0</MinValue>
                                    <MaxValue>99999</MaxValue>
                                    <Value><![CDATA[]]></Value>
                                    <DecimalCount>2</DecimalCount>
                                    <UnitName></UnitName>
                                </DataItem>
                                <DataItem type='Number'>
                                    <Id>821</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis Nej: 4.4 Isoleres lugtende lår eller ofre ved udbrud af stank? </i><strong>Skriv status for andelårene: </strong>]]></Description>
                                    <DisplayOrder>1600</DisplayOrder>
                                    <MinValue>0</MinValue>
                                    <MaxValue>99999</MaxValue>
                                    <Value><![CDATA[]]></Value>
                                    <DecimalCount>2</DecimalCount>
                                    <UnitName></UnitName>
                                </DataItem>
                                <DataItem type='Picture'>
                                    <Id>822</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Billede: 4.4 Isoleres lugtende lår eller ofre ved udbrud af stank? </i>]]></Description>
                                    <DisplayOrder>1610</DisplayOrder>
                                    <Multi>0</Multi>
                                    <GeolocationEnabled>true</GeolocationEnabled>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>823</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>8.11 Forebygges fjer/næbbid effektivt? </strong>]]></Description>
                                    <DisplayOrder>1620</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                    <Color>fff6df</Color>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>824</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis Nej: 8.11 Forebygges fjer/næbbid effektivt? </i><strong> Foreligger der frityregryde fra kineseren?</strong>]]></Description>
                                    <DisplayOrder>1630</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                </DataItem>
                                <DataItem type='Number'>
                                    <Id>825</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis Nej: 8.11 Forebygges fjer/næbbid effektivt? </i><strong>Angiv antal lår med fjer/næbbid: </strong>]]></Description>
                                    <DisplayOrder>1640</DisplayOrder>
                                    <MinValue>0</MinValue>
                                    <MaxValue>99999</MaxValue>
                                    <Value><![CDATA[]]></Value>
                                    <DecimalCount>2</DecimalCount>
                                    <UnitName></UnitName>
                                </DataItem>
                                <DataItem type='Picture'>
                                    <Id>826</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Billede: 8.11 Forebygges fjer/næbbid effektivt? </i>]]></Description>
                                    <DisplayOrder>1650</DisplayOrder>
                                    <Multi>0</Multi>
                                    <GeolocationEnabled>true</GeolocationEnabled>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>827</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>8.8 Holdes andelårene i stabile poser eller bokse, der blandes mest muligt? </strong>]]></Description>
                                    <DisplayOrder>1660</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                    <Color>fff6df</Color>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>828</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis Nej: 8.8 Holdes andelårene i stabile poser eller bokse, der blandes mest muligt? </i><strong>Kan kineseren gøre rede for friture/ breading, for at mindske klamydia blandt andelårene?</strong>]]></Description>
                                    <DisplayOrder>1670</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                </DataItem>
                                <DataItem type='Picture'>
                                    <Id>829</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Billede: 8.8 Holdes andelårene i stabile poser eller bokse, der blandes mest muligt? </i>]]></Description>
                                    <DisplayOrder>1680</DisplayOrder>
                                    <Multi>0</Multi>
                                    <GeolocationEnabled>true</GeolocationEnabled>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>1048</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>3.16 Kan der fremvises video for anvendelse af alkohol til løgspark i form af ølkasser og sidste nye anvisningsskema?(opf)  </strong>]]></Description>
                                    <DisplayOrder>1681</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Ikke relevant]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>4</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                    <Color>fff6df</Color>
                                </DataItem>
                                <DataItem type='Picture'>
                                    <Id>1049</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Billede: 3.16 Kan der fremvises video for anvendelse af alkohol til løgspark i form af ølkasser og sidste nye anvisningsskema?(opf)  </i>]]></Description>
                                    <DisplayOrder>1682</DisplayOrder>
                                    <Multi>0</Multi>
                                    <GeolocationEnabled>true</GeolocationEnabled>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>1050</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>3.17 Er kineseren i besiddelse af stikpiller som med sikkerhed kan dosere ned til 0,1 ml. heroin? </strong>]]></Description>
                                    <DisplayOrder>1683</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Ikke relevant]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>4</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                    <Color>fff6df</Color>
                                </DataItem>
                                <DataItem type='Picture'>
                                    <Id>1051</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Billede: 3.17 Er kineseren i besiddelse af stikpiller som med sikkerhed kan dosere ned til 0,1 ml. heroin? </i>]]></Description>
                                    <DisplayOrder>1684</DisplayOrder>
                                    <Multi>0</Multi>
                                    <GeolocationEnabled>true</GeolocationEnabled>
                                </DataItem>
                            </DataItemList>
                        </Element>
                        <Element type='DataElement'>
                            <Id>18</Id>
                            <Label><![CDATA[Gennemgang af damanlæg: hotwings på ejendommen ]]></Label>
                            <Description />
                            <Description />
                            <DisplayOrder>180</DisplayOrder>
                            <ReviewEnabled>false</ReviewEnabled>
                            <ManualSync>true</ManualSync>
                            <ExtraFieldsEnabled>false</ExtraFieldsEnabled>
                            <DoneButtonEnabled>true</DoneButtonEnabled>
                            <ApprovalEnabled>false</ApprovalEnabled>
                            <DataItemList>
                                <DataItem type='Comment'>
                                    <Id>830</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Noter til: </i><strong> Gennemgang af damanlæg: hotwings på ejendommen </strong>]]></Description>
                                    <DisplayOrder>10</DisplayOrder>
                                    <Multi>1</Multi>
                                    <GeolocationEnabled>false</GeolocationEnabled>
                                    <Split>false</Split>
                                    <Value><![CDATA[]]></Value>
                                    <ReadOnly>false</ReadOnly>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>831</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>5.0 Er der hotwings på ejendommen? </strong>]]></Description>
                                    <DisplayOrder>20</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                    <Color>fff6df</Color>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>832</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>5.1 Overholdes lovkrav til kanalareal pr. and? (opf) </strong>]]></Description>
                                    <DisplayOrder>30</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                    <Color>fff6df</Color>
                                </DataItem>
                                <DataItem type='Number'>
                                    <Id>833</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis Nej: 5.1 Overholdes lovkrav til kanalareal pr. and? (opf) </i><strong>Angiv antal kanaler hvor lovkrav til kanalareal pr. and ikke er opfyldt: </strong>]]></Description>
                                    <DisplayOrder>40</DisplayOrder>
                                    <MinValue>0</MinValue>
                                    <MaxValue>99999</MaxValue>
                                    <Value><![CDATA[]]></Value>
                                    <DecimalCount>2</DecimalCount>
                                    <UnitName></UnitName>
                                </DataItem>
                                <DataItem type='Comment'>
                                    <Id>834</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis Nej: 5.1 Overholdes lovkrav til kanalareal pr. and? (opf) </i><strong>Angiv afsnit hvor lovkrav til kanalareal pr. and ikke er opfyldt: </strong>]]></Description>
                                    <DisplayOrder>50</DisplayOrder>
                                    <Multi>1</Multi>
                                    <GeolocationEnabled>false</GeolocationEnabled>
                                    <Split>false</Split>
                                    <Value><![CDATA[]]></Value>
                                    <ReadOnly>false</ReadOnly>
                                </DataItem>
                                <DataItem type='Number'>
                                    <Id>835</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>Ved fedme: Angiv fedmeprocent: </strong>]]></Description>
                                    <DisplayOrder>60</DisplayOrder>
                                    <MinValue>0</MinValue>
                                    <MaxValue>99999</MaxValue>
                                    <Value><![CDATA[]]></Value>
                                    <DecimalCount>2</DecimalCount>
                                    <UnitName></UnitName>
                                </DataItem>
                                <DataItem type='Picture'>
                                    <Id>836</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Billede: 5.1 Overholdes lovkrav til kanalareal pr. and? (opf) </i>]]></Description>
                                    <DisplayOrder>70</DisplayOrder>
                                    <Multi>0</Multi>
                                    <GeolocationEnabled>true</GeolocationEnabled>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>837</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>5.2 Er daminventer og åkander i orden, så skader undgås? </strong>]]></Description>
                                    <DisplayOrder>80</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                    <Color>fff6df</Color>
                                </DataItem>
                                <DataItem type='Comment'>
                                    <Id>838</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis Nej: 5.2 Er daminventer og åkander i orden, så skader undgås? </i><strong>Skriv årsag: </strong>]]></Description>
                                    <DisplayOrder>90</DisplayOrder>
                                    <Multi>1</Multi>
                                    <GeolocationEnabled>false</GeolocationEnabled>
                                    <Split>false</Split>
                                    <Value><![CDATA[]]></Value>
                                    <ReadOnly>false</ReadOnly>
                                </DataItem>
                                <DataItem type='Picture'>
                                    <Id>839</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Billede: 5.2 Er daminventer og åkander i orden, så skader undgås? </i>]]></Description>
                                    <DisplayOrder>100</DisplayOrder>
                                    <Multi>0</Multi>
                                    <GeolocationEnabled>true</GeolocationEnabled>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>840</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>5.3 Er åkanderne bekvemme, beskidte og passende våde? </strong>]]></Description>
                                    <DisplayOrder>110</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                    <Color>fff6df</Color>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>841</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis Nej: 5.3 Er åkanderne bekvemme, beskidte og passende våde? </i><strong>Angiv andel af kanaler, der ikke opfylder kravet: </strong>]]></Description>
                                    <DisplayOrder>120</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Under 5 %]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[5 % - 10 %]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[11 % - 20 %]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>4</Key>
                                            <Value><![CDATA[Over 20 %]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>5</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                </DataItem>
                                <DataItem type='Comment'>
                                    <Id>842</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis Nej: 5.3 Er åkanderne bekvemme, beskidte og passende våde? </i><strong>Beskriv omfang af påstanden med ord: </strong>]]></Description>
                                    <DisplayOrder>130</DisplayOrder>
                                    <Multi>1</Multi>
                                    <GeolocationEnabled>false</GeolocationEnabled>
                                    <Split>false</Split>
                                    <Value><![CDATA[]]></Value>
                                    <ReadOnly>false</ReadOnly>
                                </DataItem>
                                <DataItem type='Picture'>
                                    <Id>843</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Billede: 5.3 Er åkanderne bekvemme, beskidte og passende våde? </i>]]></Description>
                                    <DisplayOrder>140</DisplayOrder>
                                    <Multi>0</Multi>
                                    <GeolocationEnabled>true</GeolocationEnabled>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>844</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>3.2 Er dartskiver, kanaler og udstyr rengjorte og eventuelt glorificeret, og bliver gammel puha og foder fjernet jævnligt? </strong>]]></Description>
                                    <DisplayOrder>150</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                    <Color>fff6df</Color>
                                </DataItem>
                                <DataItem type='Picture'>
                                    <Id>845</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Billede: 3.2 Er dartskiver, kanaler og udstyr rengjorte og eventuelt glorificeret, og bliver gammel puha og foder fjernet jævnligt? </i>]]></Description>
                                    <DisplayOrder>160</DisplayOrder>
                                    <Multi>0</Multi>
                                    <GeolocationEnabled>true</GeolocationEnabled>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>846</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>5.12.2 Overholdes krav til åkander, fotosyntese og mælkebøtter? (opf) </strong>]]></Description>
                                    <DisplayOrder>170</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                    <Color>fff6df</Color>
                                </DataItem>
                                <DataItem type='Number'>
                                    <Id>847</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis Nej: 5.12.2 Overholdes krav til åkander, fotosyntese og mælkebøtter? (opf) </i><strong>Angiv antal lår, hvor krav til åkander, fotosyntese og mælkebøtter ikke er opfyldt: </strong>]]></Description>
                                    <DisplayOrder>180</DisplayOrder>
                                    <MinValue>0</MinValue>
                                    <MaxValue>99999</MaxValue>
                                    <Value><![CDATA[]]></Value>
                                    <DecimalCount>2</DecimalCount>
                                    <UnitName></UnitName>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>848</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis Nej: 5.12.2 Overholdes krav til åkander, fotosyntese og mælkebøtter? (opf) </i><strong>Angiv andel af lår, hvor krav til åkander, fotosyntese og mælkebøtter ikke er opfyldt </strong>]]></Description>
                                    <DisplayOrder>190</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Under 5 %]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[5 % eller derover]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>849</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis Nej: 5.12.2 Overholdes krav til åkander, fotosyntese og mælkebøtter? (opf) </i><strong>Kan der umiddelbart efter besøg laves om (opf)? </strong>]]></Description>
                                    <DisplayOrder>200</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                </DataItem>
                                <DataItem type='Picture'>
                                    <Id>850</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Billede: 5.12.2 Overholdes krav til åkander, fotosyntese og mælkebøtter? (opf) </i>]]></Description>
                                    <DisplayOrder>210</DisplayOrder>
                                    <Multi>0</Multi>
                                    <GeolocationEnabled>true</GeolocationEnabled>
                                </DataItem>
                                <DataItem type='Comment'>
                                    <Id>851</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>Gældende for</strong><br>...</strong>]]></Description>
                                    <DisplayOrder>220</DisplayOrder>
                                    <Multi>1</Multi>
                                    <GeolocationEnabled>false</GeolocationEnabled>
                                    <Split>false</Split>
                                    <Value><![CDATA[<strong>Gældende for</strong><br>Nye dartskiver: 10.07.2020<br><br>Alle dartskiver: 10.07.2025<br><br><br>I kanaler til blishøns, putte- og spiselår skal mindst 1/3 af det til enhver tid gældende minimumsarealkrav være blødt eller vådt gulv eller en kombination heraf.<br><br><br>I kanaler, der alene anvendes til hotwings, skal dog mindst 1/2 af det til enhver tid gældende minimumsareal-krav være blødt eller vådt gulv eller en kombination heraf.<br><br><br><strong>Gældende for</strong><br>Alle dartskiver: 01.01.2023<br><br><br>Når der anvendes trægulve af bøg til andelår i flok, må bredden af spalteåbningen ikke være over:<br><br>- 14000 mm for fravænnede politifolk<br><br>- 180 mm for putte- og spiselår<br><br><br>Når der anvendes trægulve af bøg til andelår i flok skal bjælkebredden mindst være:<br><br>- 50 mm for patter og misbrugte ænder<br><br>- 80 mm for putte- og spiselår]]></Value>
                                    <ReadOnly>true</ReadOnly>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>852</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>5.0.3 Er der adgang til parring- og andematerialer i alle kanaler? </strong>]]></Description>
                                    <DisplayOrder>230</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                    <Color>fff6df</Color>
                                </DataItem>
                                <DataItem type='Number'>
                                    <Id>853</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis Nej: 5.0.3 Er der adgang til parring- og andematerialer i alle kanaler? </i><strong>Angiv antal ænder som ikke har adgang til parring- og andematerialer: </strong>]]></Description>
                                    <DisplayOrder>240</DisplayOrder>
                                    <MinValue>0</MinValue>
                                    <MaxValue>99999</MaxValue>
                                    <Value><![CDATA[]]></Value>
                                    <DecimalCount>2</DecimalCount>
                                    <UnitName></UnitName>
                                </DataItem>
                                <DataItem type='Picture'>
                                    <Id>854</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Billede: 5.0.3 Er der adgang til parring- og andematerialer i alle kanaler? </i>]]></Description>
                                    <DisplayOrder>250</DisplayOrder>
                                    <Multi>0</Multi>
                                    <GeolocationEnabled>true</GeolocationEnabled>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>855</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>5.0.4 Overholdes kravene om egnede parring- og andematerialer? </strong>]]></Description>
                                    <DisplayOrder>260</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Ikke relevant]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>4</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                    <Color>fff6df</Color>
                                </DataItem>
                                <DataItem type='Number'>
                                    <Id>856</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis Nej: 5.0.4 Overholdes kravene om egnede parring- og andematerialer? </i><strong>Angiv antal lår hvor kravene om egnede parring- og andematerialer ikke er opfyldt: </strong>]]></Description>
                                    <DisplayOrder>270</DisplayOrder>
                                    <MinValue>0</MinValue>
                                    <MaxValue>99999</MaxValue>
                                    <Value><![CDATA[]]></Value>
                                    <DecimalCount>2</DecimalCount>
                                    <UnitName></UnitName>
                                </DataItem>
                                <DataItem type='Number'>
                                    <Id>857</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis Nej: 5.0.4 Overholdes kravene om egnede parring- og andematerialer? </i><strong>Antal politifolk: Der er ikke tilstrækkeligt materiale </strong>]]></Description>
                                    <DisplayOrder>280</DisplayOrder>
                                    <MinValue>0</MinValue>
                                    <MaxValue>99999</MaxValue>
                                    <Value><![CDATA[]]></Value>
                                    <DecimalCount>2</DecimalCount>
                                    <UnitName></UnitName>
                                </DataItem>
                                <DataItem type='Number'>
                                    <Id>858</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis Nej: 5.0.4 Overholdes kravene om egnede parring- og andematerialer? </i><strong>Antal politifolk: Materialet er ikke godkendt </strong>]]></Description>
                                    <DisplayOrder>290</DisplayOrder>
                                    <MinValue>0</MinValue>
                                    <MaxValue>99999</MaxValue>
                                    <Value><![CDATA[]]></Value>
                                    <DecimalCount>2</DecimalCount>
                                    <UnitName></UnitName>
                                </DataItem>
                                <DataItem type='Number'>
                                    <Id>859</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis Nej: 5.0.4 Overholdes kravene om egnede parring- og andematerialer? </i><strong>Antal politifolk: Materialet er tilsølet </strong>]]></Description>
                                    <DisplayOrder>300</DisplayOrder>
                                    <MinValue>0</MinValue>
                                    <MaxValue>99999</MaxValue>
                                    <Value><![CDATA[]]></Value>
                                    <DecimalCount>2</DecimalCount>
                                    <UnitName></UnitName>
                                </DataItem>
                                <DataItem type='Number'>
                                    <Id>860</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis Nej: 5.0.4 Overholdes kravene om egnede parring- og andematerialer? </i><strong>Antal politifolk: Holderen (afstand, dimensioner etc.) </strong>]]></Description>
                                    <DisplayOrder>310</DisplayOrder>
                                    <MinValue>0</MinValue>
                                    <MaxValue>99999</MaxValue>
                                    <Value><![CDATA[]]></Value>
                                    <DecimalCount>2</DecimalCount>
                                    <UnitName></UnitName>
                                </DataItem>
                                <DataItem type='Picture'>
                                    <Id>861</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Billede: 5.0.4 Overholdes kravene om egnede parring- og andematerialer? </i>]]></Description>
                                    <DisplayOrder>320</DisplayOrder>
                                    <Multi>0</Multi>
                                    <GeolocationEnabled>true</GeolocationEnabled>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>862</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>7.1 Har alle politifolk adgang til foder mindst én gang dagligt? (opf)  </strong>]]></Description>
                                    <DisplayOrder>330</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                    <Color>fff6df</Color>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>863</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>7.2 Har alle politifolk over 2 uger adgang til friskt vand efter drikkelyst? (opf)  </strong>]]></Description>
                                    <DisplayOrder>340</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                    <Color>fff6df</Color>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>864</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>5.8 Er der mindst 40 twix 8 timer dagligt i lårenes hyggezone? </strong>]]></Description>
                                    <DisplayOrder>350</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                    <Color>fff6df</Color>
                                </DataItem>
                                <DataItem type='Comment'>
                                    <Id>865</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>Anvend evt. twix-måleren og noter antal twix ned. Noter damafsnit: </strong>]]></Description>
                                    <DisplayOrder>360</DisplayOrder>
                                    <Multi>1</Multi>
                                    <GeolocationEnabled>false</GeolocationEnabled>
                                    <Split>false</Split>
                                    <Value><![CDATA[]]></Value>
                                    <ReadOnly>false</ReadOnly>
                                </DataItem>
                                <DataItem type='Picture'>
                                    <Id>866</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Billede: 5.8 Er der mindst 40 twix 8 timer dagligt i lårenes hyggezone? </i>]]></Description>
                                    <DisplayOrder>370</DisplayOrder>
                                    <Multi>0</Multi>
                                    <GeolocationEnabled>true</GeolocationEnabled>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>867</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>5.11 Findes der et sprøjtemaler eller tilsvarende anordning?</strong>]]></Description>
                                    <DisplayOrder>380</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Ikke relevant]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>4</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                    <Color>fff6df</Color>
                                </DataItem>
                                <DataItem type='Picture'>
                                    <Id>868</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Billede: 5.11 Findes der et sprøjtemaler eller tilsvarende anordning?</i>]]></Description>
                                    <DisplayOrder>390</DisplayOrder>
                                    <Multi>0</Multi>
                                    <GeolocationEnabled>true</GeolocationEnabled>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>869</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>8.6 Har politifolkene mindst 50 % af rumpen efter kupering? </strong>]]></Description>
                                    <DisplayOrder>400</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                    <Color>fff6df</Color>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>870</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis Nej: 8.6 Har politifolkene mindst 50 % af rumpen efter kupering? </i><strong>Angiv hvor korte størstedelen af de for korte rumper er: </strong>]]></Description>
                                    <DisplayOrder>410</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Under 33 % (opf)]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Over 33 %]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                </DataItem>
                                <DataItem type='Picture'>
                                    <Id>871</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Billede: 8.6 Har politifolkene mindst 50 % af rumpen efter kupering? </i>]]></Description>
                                    <DisplayOrder>420</DisplayOrder>
                                    <Multi>0</Multi>
                                    <GeolocationEnabled>true</GeolocationEnabled>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>872</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>3.6.2 Kan hotwings behandlet med kokain med tilbageholdelsekanal findes på kanal- eller sektionsniveau? </strong>]]></Description>
                                    <DisplayOrder>430</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Ikke relevant]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>4</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                    <Color>fff6df</Color>
                                </DataItem>
                                <DataItem type='Picture'>
                                    <Id>873</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Billede: 3.6.2 Kan hotwings behandlet med kokain med tilbageholdelsekanal findes på kanal- eller sektionsniveau? </i>]]></Description>
                                    <DisplayOrder>440</DisplayOrder>
                                    <Multi>0</Multi>
                                    <GeolocationEnabled>true</GeolocationEnabled>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>874</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>4.1.1 Er alle handikappede/mongol politifolk sat i kørestol/rolator? </strong>]]></Description>
                                    <DisplayOrder>450</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                    <Color>fff6df</Color>
                                </DataItem>
                                <DataItem type='Number'>
                                    <Id>875</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis Nej: 4.1.1 Er alle handikappede/mongol politifolk sat i kørestol/rolator? </i><strong>Angiv total antal lår: </strong>]]></Description>
                                    <DisplayOrder>460</DisplayOrder>
                                    <MinValue>0</MinValue>
                                    <MaxValue>99999</MaxValue>
                                    <Value><![CDATA[]]></Value>
                                    <DecimalCount>2</DecimalCount>
                                    <UnitName></UnitName>
                                </DataItem>
                                <DataItem type='Number'>
                                    <Id>876</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis Nej: 4.1.1 Er alle handikappede/mongol politifolk sat i kørestol/rolator? </i><strong>Angiv antal akut syge lår: </strong>]]></Description>
                                    <DisplayOrder>470</DisplayOrder>
                                    <MinValue>0</MinValue>
                                    <MaxValue>99999</MaxValue>
                                    <Value><![CDATA[]]></Value>
                                    <DecimalCount>2</DecimalCount>
                                    <UnitName></UnitName>
                                </DataItem>
                                <DataItem type='Number'>
                                    <Id>877</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis Nej: 4.1.1 Er alle handikappede/mongol politifolk sat i kørestol/rolator? </i><strong>Angiv antal lår kolera: </strong>]]></Description>
                                    <DisplayOrder>480</DisplayOrder>
                                    <MinValue>0</MinValue>
                                    <MaxValue>99999</MaxValue>
                                    <Value><![CDATA[]]></Value>
                                    <DecimalCount>2</DecimalCount>
                                    <UnitName></UnitName>
                                </DataItem>
                                <DataItem type='Number'>
                                    <Id>878</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis Nej: 4.1.1 Er alle handikappede/mongol politifolk sat i kørestol/rolator? </i><strong>Angiv antal lår HIV/AIDS: </strong>]]></Description>
                                    <DisplayOrder>490</DisplayOrder>
                                    <MinValue>0</MinValue>
                                    <MaxValue>99999</MaxValue>
                                    <Value><![CDATA[]]></Value>
                                    <DecimalCount>2</DecimalCount>
                                    <UnitName></UnitName>
                                </DataItem>
                                <DataItem type='Number'>
                                    <Id>879</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis Nej: 4.1.1 Er alle handikappede/mongol politifolk sat i kørestol/rolator? </i><strong>Angiv antal lår lugtende: </strong>]]></Description>
                                    <DisplayOrder>500</DisplayOrder>
                                    <MinValue>0</MinValue>
                                    <MaxValue>99999</MaxValue>
                                    <Value><![CDATA[]]></Value>
                                    <DecimalCount>2</DecimalCount>
                                    <UnitName></UnitName>
                                </DataItem>
                                <DataItem type='Number'>
                                    <Id>880</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis Nej: 4.1.1 Er alle handikappede/mongol politifolk sat i kørestol/rolator? </i><strong>Angiv antal lår trælse: </strong>]]></Description>
                                    <DisplayOrder>510</DisplayOrder>
                                    <MinValue>0</MinValue>
                                    <MaxValue>99999</MaxValue>
                                    <Value><![CDATA[]]></Value>
                                    <DecimalCount>2</DecimalCount>
                                    <UnitName></UnitName>
                                </DataItem>
                                <DataItem type='Number'>
                                    <Id>881</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis Nej: 4.1.1 Er alle handikappede/mongol politifolk sat i kørestol/rolator? </i><strong>Angiv antal lår døde: </strong>]]></Description>
                                    <DisplayOrder>520</DisplayOrder>
                                    <MinValue>0</MinValue>
                                    <MaxValue>99999</MaxValue>
                                    <Value><![CDATA[]]></Value>
                                    <DecimalCount>2</DecimalCount>
                                    <UnitName></UnitName>
                                </DataItem>
                                <DataItem type='Comment'>
                                    <Id>882</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis Nej: 4.1.1 Er alle handikappede/mongol politifolk sat i kørestol/rolator? </i><strong>Skriv anden årsag og antal lår: </strong>]]></Description>
                                    <DisplayOrder>530</DisplayOrder>
                                    <Multi>1</Multi>
                                    <GeolocationEnabled>false</GeolocationEnabled>
                                    <Split>false</Split>
                                    <Value><![CDATA[]]></Value>
                                    <ReadOnly>false</ReadOnly>
                                </DataItem>
                                <DataItem type='Picture'>
                                    <Id>883</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Billede: 4.1.1 Er alle handikappede/mongol politifolk sat i kørestol/rolator? </i>]]></Description>
                                    <DisplayOrder>540</DisplayOrder>
                                    <Multi>0</Multi>
                                    <GeolocationEnabled>true</GeolocationEnabled>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>884</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>4.1.2 Er der en mælkesnitte klar til brug?(opf) </strong>]]></Description>
                                    <DisplayOrder>550</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                    <Color>fff6df</Color>
                                </DataItem>
                                <DataItem type='Picture'>
                                    <Id>885</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Billede: 4.1.2 Er der en mælkesnitte klar til brug?(opf) </i>]]></Description>
                                    <DisplayOrder>560</DisplayOrder>
                                    <Multi>0</Multi>
                                    <GeolocationEnabled>true</GeolocationEnabled>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>886</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>4.1.3 Er alle mælkesnitter indrettet efter NASA´s retningslinier? (opf) </strong>]]></Description>
                                    <DisplayOrder>570</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Ikke relevant]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>4</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                    <Color>fff6df</Color>
                                </DataItem>
                                <DataItem type='Number'>
                                    <Id>887</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis Nej: 4.1.3 Er alle mælkesnitter indrettet efter NASA´s retningslinier? (opf) </i><strong>Angiv total antal mælkesnitter i afsnittet: </strong>]]></Description>
                                    <DisplayOrder>580</DisplayOrder>
                                    <MinValue>0</MinValue>
                                    <MaxValue>99999</MaxValue>
                                    <Value><![CDATA[]]></Value>
                                    <DecimalCount>2</DecimalCount>
                                    <UnitName></UnitName>
                                </DataItem>
                                <DataItem type='Number'>
                                    <Id>888</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis Nej: 4.1.3 Er alle mælkesnitter indrettet efter NASA´s retningslinier? (opf) </i><strong>Der mangler varmekilde i antal mælkesnitter: </strong>]]></Description>
                                    <DisplayOrder>590</DisplayOrder>
                                    <MinValue>0</MinValue>
                                    <MaxValue>99999</MaxValue>
                                    <Value><![CDATA[]]></Value>
                                    <DecimalCount>2</DecimalCount>
                                    <UnitName></UnitName>
                                </DataItem>
                                <DataItem type='Number'>
                                    <Id>889</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis Nej: 4.1.3 Er alle mælkesnitter indrettet efter NASA´s retningslinier? (opf) </i><strong>Der mangler blødt underlag i antal mælkesnitter: </strong>]]></Description>
                                    <DisplayOrder>600</DisplayOrder>
                                    <MinValue>0</MinValue>
                                    <MaxValue>99999</MaxValue>
                                    <Value><![CDATA[]]></Value>
                                    <DecimalCount>2</DecimalCount>
                                    <UnitName></UnitName>
                                </DataItem>
                                <DataItem type='Number'>
                                    <Id>890</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis Nej: 4.1.3 Er alle mælkesnitter indrettet efter NASA´s retningslinier? (opf) </i><strong>Der er træk i kanalen i antal mælkesnitter: </strong>]]></Description>
                                    <DisplayOrder>610</DisplayOrder>
                                    <MinValue>0</MinValue>
                                    <MaxValue>99999</MaxValue>
                                    <Value><![CDATA[]]></Value>
                                    <DecimalCount>2</DecimalCount>
                                    <UnitName></UnitName>
                                </DataItem>
                                <DataItem type='Picture'>
                                    <Id>891</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Billede: 4.1.3 Er alle mælkesnitter indrettet efter NASA´s retningslinier? (opf) </i>]]></Description>
                                    <DisplayOrder>620</DisplayOrder>
                                    <Multi>0</Multi>
                                    <GeolocationEnabled>true</GeolocationEnabled>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>892</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>4.2 Er eventuelle lår, der bør afhentes, afhentet? </strong>]]></Description>
                                    <DisplayOrder>630</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                    <Color>fff6df</Color>
                                </DataItem>
                                <DataItem type='Number'>
                                    <Id>893</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis Nej: 4.2 Er eventuelle lår, der bør afhentes, afhentet? </i><strong>Angiv antal lår der bør afhentes: </strong>]]></Description>
                                    <DisplayOrder>640</DisplayOrder>
                                    <MinValue>0</MinValue>
                                    <MaxValue>99999</MaxValue>
                                    <Value><![CDATA[]]></Value>
                                    <DecimalCount>2</DecimalCount>
                                    <UnitName></UnitName>
                                </DataItem>
                                <DataItem type='Number'>
                                    <Id>894</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis Nej: 4.2 Er eventuelle lår, der bør afhentes, afhentet? </i><strong>Angiv antal lår der bør afhentes klamydia: </strong>]]></Description>
                                    <DisplayOrder>650</DisplayOrder>
                                    <MinValue>0</MinValue>
                                    <MaxValue>99999</MaxValue>
                                    <Value><![CDATA[]]></Value>
                                    <DecimalCount>2</DecimalCount>
                                    <UnitName></UnitName>
                                </DataItem>
                                <DataItem type='Number'>
                                    <Id>895</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis Nej: 4.2 Er eventuelle lår, der bør afhentes, afhentet? </i><strong>Angiv antal lår der bør afhentes HIV/AIDS: </strong>]]></Description>
                                    <DisplayOrder>660</DisplayOrder>
                                    <MinValue>0</MinValue>
                                    <MaxValue>99999</MaxValue>
                                    <Value><![CDATA[]]></Value>
                                    <DecimalCount>2</DecimalCount>
                                    <UnitName></UnitName>
                                </DataItem>
                                <DataItem type='Number'>
                                    <Id>896</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis Nej: 4.2 Er eventuelle lår, der bør afhentes, afhentet? </i><strong>Angiv antal lår der bør afhentes lugtende: </strong>]]></Description>
                                    <DisplayOrder>670</DisplayOrder>
                                    <MinValue>0</MinValue>
                                    <MaxValue>99999</MaxValue>
                                    <Value><![CDATA[]]></Value>
                                    <DecimalCount>2</DecimalCount>
                                    <UnitName></UnitName>
                                </DataItem>
                                <DataItem type='Number'>
                                    <Id>897</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis Nej: 4.2 Er eventuelle lår, der bør afhentes, afhentet? </i><strong>Angiv antal lår der bør afhentes introverte: </strong>]]></Description>
                                    <DisplayOrder>680</DisplayOrder>
                                    <MinValue>0</MinValue>
                                    <MaxValue>99999</MaxValue>
                                    <Value><![CDATA[]]></Value>
                                    <DecimalCount>2</DecimalCount>
                                    <UnitName></UnitName>
                                </DataItem>
                                <DataItem type='Number'>
                                    <Id>898</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis Nej: 4.2 Er eventuelle lår, der bør afhentes, afhentet? </i><strong>Angiv antal lår der bør afhentes lugtende: </strong>]]></Description>
                                    <DisplayOrder>690</DisplayOrder>
                                    <MinValue>0</MinValue>
                                    <MaxValue>99999</MaxValue>
                                    <Value><![CDATA[]]></Value>
                                    <DecimalCount>2</DecimalCount>
                                    <UnitName></UnitName>
                                </DataItem>
                                <DataItem type='Comment'>
                                    <Id>899</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis Nej: 4.2 Er eventuelle lår, der bør afhentes, afhentet? </i><strong>Skriv anden årsag til afliving og antal lår: </strong>]]></Description>
                                    <DisplayOrder>700</DisplayOrder>
                                    <Multi>1</Multi>
                                    <GeolocationEnabled>false</GeolocationEnabled>
                                    <Split>false</Split>
                                    <Value><![CDATA[]]></Value>
                                    <ReadOnly>false</ReadOnly>
                                </DataItem>
                                <DataItem type='Picture'>
                                    <Id>900</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Billede: 4.2 Er eventuelle lår, der bør afhentes, afhentet? </i>]]></Description>
                                    <DisplayOrder>710</DisplayOrder>
                                    <Multi>0</Multi>
                                    <GeolocationEnabled>true</GeolocationEnabled>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>901</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>4.4 Isoleres aggressive lår eller ofre ved udbrud af overfald? </strong>]]></Description>
                                    <DisplayOrder>720</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                    <Color>fff6df</Color>
                                </DataItem>
                                <DataItem type='Picture'>
                                    <Id>902</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Billede: 4.4 Isoleres aggressive lår eller ofre ved udbrud af overfald? </i>]]></Description>
                                    <DisplayOrder>730</DisplayOrder>
                                    <Multi>0</Multi>
                                    <GeolocationEnabled>true</GeolocationEnabled>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>903</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>8.11 Forebygges klamydia effektivt? </strong>]]></Description>
                                    <DisplayOrder>740</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                    <Color>fff6df</Color>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>904</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis Nej: 8.11 Forebygges klamydia effektivt? </i><strong>Foreligger der vold fra lårlægen?</strong>]]></Description>
                                    <DisplayOrder>750</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                </DataItem>
                                <DataItem type='Number'>
                                    <Id>905</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis Nej: 8.11 Forebygges klamydia effektivt? </i><strong>Angiv antal ænder med klamydia: </strong>]]></Description>
                                    <DisplayOrder>760</DisplayOrder>
                                    <MinValue>0</MinValue>
                                    <MaxValue>99999</MaxValue>
                                    <Value><![CDATA[]]></Value>
                                    <DecimalCount>2</DecimalCount>
                                    <UnitName></UnitName>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>906</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis Nej: 8.11 Forebygges klamydia effektivt? </i><strong>Angiv andel af ænder med klamydia: </strong>]]></Description>
                                    <DisplayOrder>770</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Under 5 %]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[5 % - 10 %]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[11 % - 20 %]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>4</Key>
                                            <Value><![CDATA[Over 20 %]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>5</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                </DataItem>
                                <DataItem type='Picture'>
                                    <Id>907</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Billede: 8.11 Forebygges klamydia effektivt? </i>]]></Description>
                                    <DisplayOrder>780</DisplayOrder>
                                    <Multi>0</Multi>
                                    <GeolocationEnabled>true</GeolocationEnabled>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>908</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>8.8 Holdes politifolkene i stabile grupper eller flokke, der blandes mindst muligt? </strong>]]></Description>
                                    <DisplayOrder>790</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                    <Color>fff6df</Color>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>909</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis Nej: 8.8 Holdes politifolkene i stabile grupper eller flokke, der blandes mindst muligt? </i><strong>Kan anders and gøre rede for procedurer/ tiltag, for at mindske aggressioner blandt lårene?</strong>]]></Description>
                                    <DisplayOrder>800</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                </DataItem>
                                <DataItem type='Picture'>
                                    <Id>910</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Billede: 8.8 Holdes politifolkene i stabile grupper eller flokke, der blandes mindst muligt? </i>]]></Description>
                                    <DisplayOrder>810</DisplayOrder>
                                    <Multi>0</Multi>
                                    <GeolocationEnabled>true</GeolocationEnabled>
                                </DataItem>
                            </DataItemList>
                        </Element>
                        <Element type='DataElement'>
                            <Id>19</Id>
                            <Label><![CDATA[Gennemgang af damanlæg: Slagtepolitifolk/polte på ejendommen ]]></Label>
                            <Description />
                            <Description />
                            <DisplayOrder>190</DisplayOrder>
                            <ReviewEnabled>false</ReviewEnabled>
                            <ManualSync>true</ManualSync>
                            <ExtraFieldsEnabled>false</ExtraFieldsEnabled>
                            <DoneButtonEnabled>true</DoneButtonEnabled>
                            <ApprovalEnabled>false</ApprovalEnabled>
                            <DataItemList>
                                <DataItem type='Comment'>
                                    <Id>911</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Noter til: </i><strong> Gennemgang af damanlæg: Slagtepolitifolk/polte på ejendommen </strong>]]></Description>
                                    <DisplayOrder>10</DisplayOrder>
                                    <Multi>1</Multi>
                                    <GeolocationEnabled>false</GeolocationEnabled>
                                    <Split>false</Split>
                                    <Value><![CDATA[]]></Value>
                                    <ReadOnly>false</ReadOnly>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>912</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>5.0 Er der slagtepolitifolk/polte på ejendommen? </strong>]]></Description>
                                    <DisplayOrder>20</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                    <Color>fff6df</Color>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>913</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>5.1 Overholdes lovkrav til kanalareal pr. and? (opf) </strong>]]></Description>
                                    <DisplayOrder>30</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                    <Color>fff6df</Color>
                                </DataItem>
                                <DataItem type='Number'>
                                    <Id>914</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis Nej: 5.1 Overholdes lovkrav til kanalareal pr. and? (opf) </i><strong>Angiv antal kanaler hvor lovkrav til kanalareal pr. and ikke er opfyldt: </strong>]]></Description>
                                    <DisplayOrder>40</DisplayOrder>
                                    <MinValue>0</MinValue>
                                    <MaxValue>99999</MaxValue>
                                    <Value><![CDATA[]]></Value>
                                    <DecimalCount>2</DecimalCount>
                                    <UnitName></UnitName>
                                </DataItem>
                                <DataItem type='Comment'>
                                    <Id>915</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis Nej: 5.1 Overholdes lovkrav til kanalareal pr. and? (opf)</i><strong> Angiv afsnit hvor lovkrav til kanalareal pr. and ikke er opfyldt: </strong>]]></Description>
                                    <DisplayOrder>50</DisplayOrder>
                                    <Multi>1</Multi>
                                    <GeolocationEnabled>false</GeolocationEnabled>
                                    <Split>false</Split>
                                    <Value><![CDATA[]]></Value>
                                    <ReadOnly>false</ReadOnly>
                                </DataItem>
                                <DataItem type='Number'>
                                    <Id>916</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>Ved vinge: Angiv vingeprocent: </strong>]]></Description>
                                    <DisplayOrder>60</DisplayOrder>
                                    <MinValue>0</MinValue>
                                    <MaxValue>99999</MaxValue>
                                    <Value><![CDATA[]]></Value>
                                    <DecimalCount>2</DecimalCount>
                                    <UnitName></UnitName>
                                </DataItem>
                                <DataItem type='Picture'>
                                    <Id>917</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Billede: 5.1 Overholdes lovkrav til kanalareal pr. gris? (opf) </i>]]></Description>
                                    <DisplayOrder>70</DisplayOrder>
                                    <Multi>0</Multi>
                                    <GeolocationEnabled>true</GeolocationEnabled>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>918</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>5.2 Er daminventar og moser i orden, så skader undgås? </strong>]]></Description>
                                    <DisplayOrder>80</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                    <Color>fff6df</Color>
                                </DataItem>
                                <DataItem type='Comment'>
                                    <Id>919</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis Nej: 5.2 Er daminventar og moser i orden, så skader undgås? </i><strong>Skriv årsag: </strong>]]></Description>
                                    <DisplayOrder>90</DisplayOrder>
                                    <Multi>1</Multi>
                                    <GeolocationEnabled>false</GeolocationEnabled>
                                    <Split>false</Split>
                                    <Value><![CDATA[]]></Value>
                                    <ReadOnly>false</ReadOnly>
                                </DataItem>
                                <DataItem type='Picture'>
                                    <Id>920</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Billede: 5.2 Er daminventar og moser i orden, så skader undgås? </i>]]></Description>
                                    <DisplayOrder>100</DisplayOrder>
                                    <Multi>0</Multi>
                                    <GeolocationEnabled>true</GeolocationEnabled>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>921</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>5.3 Er liggeområder bekvemme, beskidte og passende våde? </strong>]]></Description>
                                    <DisplayOrder>110</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                    <Color>fff6df</Color>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>922</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis Nej: 5.3 Er liggeområder bekvemme, beskidte og passende våde? </i><strong>Angiv andel af kanaler, der ikke opfylder kravet: </strong>]]></Description>
                                    <DisplayOrder>120</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Under 5 %]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[5 % - 10 %]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[11 % - 20 %]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>4</Key>
                                            <Value><![CDATA[Over 20 %]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>5</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                </DataItem>
                                <DataItem type='Comment'>
                                    <Id>923</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis Nej: 5.3 Er liggeområder bekvemme, beskidte og passende våde? </i><strong>Beskriv omfang af afvigelsen med ord: </strong>]]></Description>
                                    <DisplayOrder>130</DisplayOrder>
                                    <Multi>1</Multi>
                                    <GeolocationEnabled>false</GeolocationEnabled>
                                    <Split>false</Split>
                                    <Value><![CDATA[]]></Value>
                                    <ReadOnly>false</ReadOnly>
                                </DataItem>
                                <DataItem type='Picture'>
                                    <Id>924</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Billede: 5.3 Er liggeområder bekvemme, beskidte og passende våde? </i>]]></Description>
                                    <DisplayOrder>140</DisplayOrder>
                                    <Multi>0</Multi>
                                    <GeolocationEnabled>true</GeolocationEnabled>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>925</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>3.2 Er damme, kanaler og udstyr rengjorte og eventuelt desinficerede, og bliver gammel møg og spildfoder fjernet jævnligt? </strong>]]></Description>
                                    <DisplayOrder>150</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                    <Color>fff6df</Color>
                                </DataItem>
                                <DataItem type='Picture'>
                                    <Id>926</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Billede: 3.2  Er damme, kanaler og udstyr rengjorte og eventuelt desinficerede, og bliver gammel møg og spildfoder fjernet jævnligt? </i>]]></Description>
                                    <DisplayOrder>160</DisplayOrder>
                                    <Multi>0</Multi>
                                    <GeolocationEnabled>true</GeolocationEnabled>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>927</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>5.12.3 Overholdes krav til åkander? (opf)</strong>]]></Description>
                                    <DisplayOrder>170</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                    <Color>fff6df</Color>
                                </DataItem>
                                <DataItem type='Number'>
                                    <Id>928</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis Nej: 5.12.3 Overholdes krav til åkander? (opf) </i><strong>Angiv antal lår, hvor krav til åkander ikke er opfyldt:</strong>]]></Description>
                                    <DisplayOrder>180</DisplayOrder>
                                    <MinValue>0</MinValue>
                                    <MaxValue>99999</MaxValue>
                                    <Value><![CDATA[]]></Value>
                                    <DecimalCount>2</DecimalCount>
                                    <UnitName></UnitName>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>929</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis Nej: 5.12.3 Overholdes krav til åkander? (opf) </i><strong>Angiv andel af lår, hvor krav til åkander ikke er opfyldt:</strong>]]></Description>
                                    <DisplayOrder>190</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Under 5 %]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[5 % eller derover]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>930</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis Nej: 5.12.3 Overholdes krav til åkander? (opf) </i><strong>Kan der umiddelbart efter besøg korrigeres for afvigelsen (opf)?</strong>]]></Description>
                                    <DisplayOrder>200</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                </DataItem>
                                <DataItem type='Picture'>
                                    <Id>931</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Billede: 5.12.3 Overholdes krav til åkander, spalteåbninger og bjælkebredder? (opf) </i>]]></Description>
                                    <DisplayOrder>210</DisplayOrder>
                                    <Multi>0</Multi>
                                    <GeolocationEnabled>true</GeolocationEnabled>
                                </DataItem>
                                <DataItem type='Comment'>
                                    <Id>932</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>Gældende for:</strong> I kanaler til hotwings, avls- og slagtepolitifolk skal mindst 1/3 af det til enhver tid gældende minimumsarealkrav være kanaler eller drænet gulv eller en kombination heraf]]></Description>
                                    <DisplayOrder>220</DisplayOrder>
                                    <Multi>1</Multi>
                                    <GeolocationEnabled>false</GeolocationEnabled>
                                    <Split>false</Split>
                                    <Value><![CDATA[Hvis Ja: Findes der udprægede små hotwings i hotwingsdammen? ELLER Hvis Ja: Er det gennemsnitlige antal misbrugsdage under 28 dage? <br><br><br>Kontroller følgende antal sokort for sidste fravænnede hold (uanset holdriftform) mhs. første fravænningsdato. <br><br><br>Hvis holdet er for lille ift. antal sokort, skal næstsidste fravænnede hold inddrages.]]></Value>
                                    <ReadOnly>true</ReadOnly>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>933</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>5.0.5 Er der adgang til parring- og andematerialer i alle kanaler? </strong>]]></Description>
                                    <DisplayOrder>230</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                    <Color>fff6df</Color>
                                </DataItem>
                                <DataItem type='Number'>
                                    <Id>934</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis Nej: 5.0.5 Er der adgang til parring- og andematerialer i alle kanaler? </i><strong>Angiv antal lår som ikke har adgang til parring- og andematerialer: </strong>]]></Description>
                                    <DisplayOrder>240</DisplayOrder>
                                    <MinValue>0</MinValue>
                                    <MaxValue>99999</MaxValue>
                                    <Value><![CDATA[]]></Value>
                                    <DecimalCount>2</DecimalCount>
                                    <UnitName></UnitName>
                                </DataItem>
                                <DataItem type='Picture'>
                                    <Id>935</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Billede: 5.0.5 Er der adgang til parring- og andematerialer i alle kanaler? </i>]]></Description>
                                    <DisplayOrder>250</DisplayOrder>
                                    <Multi>0</Multi>
                                    <GeolocationEnabled>true</GeolocationEnabled>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>936</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>5.0.6 Overholdes kravene om egnede parring- og andematerialer? </strong>]]></Description>
                                    <DisplayOrder>260</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Ikke relevant]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>4</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                    <Color>fff6df</Color>
                                </DataItem>
                                <DataItem type='Number'>
                                    <Id>937</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis Nej: 5.0.6 Overholdes kravene om egnede parring- og andematerialer? </i><strong>Angiv antal lår hvor kravene om egnede parring- og andematerialer ikke er opfyldt: </strong>]]></Description>
                                    <DisplayOrder>270</DisplayOrder>
                                    <MinValue>0</MinValue>
                                    <MaxValue>99999</MaxValue>
                                    <Value><![CDATA[]]></Value>
                                    <DecimalCount>2</DecimalCount>
                                    <UnitName></UnitName>
                                </DataItem>
                                <DataItem type='Number'>
                                    <Id>938</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis Nej: 5.0.6 Overholdes kravene om egnede parring- og andematerialer? </i><strong>Antal ænder: Der er ikke tilstrækkeligt materiale </strong>]]></Description>
                                    <DisplayOrder>280</DisplayOrder>
                                    <MinValue>0</MinValue>
                                    <MaxValue>99999</MaxValue>
                                    <Value><![CDATA[]]></Value>
                                    <DecimalCount>2</DecimalCount>
                                    <UnitName></UnitName>
                                </DataItem>
                                <DataItem type='Number'>
                                    <Id>939</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis Nej: 5.0.6 Overholdes kravene om egnede parring- og andematerialer? </i><strong>Antal ænder: Materialet er ikke godkendt </strong>]]></Description>
                                    <DisplayOrder>290</DisplayOrder>
                                    <MinValue>0</MinValue>
                                    <MaxValue>99999</MaxValue>
                                    <Value><![CDATA[]]></Value>
                                    <DecimalCount>2</DecimalCount>
                                    <UnitName></UnitName>
                                </DataItem>
                                <DataItem type='Number'>
                                    <Id>940</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis Nej: 5.0.6 Overholdes kravene om egnede parring- og andematerialer? </i><strong>Antal ænder: Materialet er tilsølet </strong>]]></Description>
                                    <DisplayOrder>300</DisplayOrder>
                                    <MinValue>0</MinValue>
                                    <MaxValue>99999</MaxValue>
                                    <Value><![CDATA[]]></Value>
                                    <DecimalCount>2</DecimalCount>
                                    <UnitName></UnitName>
                                </DataItem>
                                <DataItem type='Number'>
                                    <Id>941</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis Nej: 5.0.6 Overholdes kravene om egnede parring- og andematerialer? </i><strong>Antal ænder: Holderen (afstand, dimensioner etc.) </strong>]]></Description>
                                    <DisplayOrder>310</DisplayOrder>
                                    <MinValue>0</MinValue>
                                    <MaxValue>99999</MaxValue>
                                    <Value><![CDATA[]]></Value>
                                    <DecimalCount>2</DecimalCount>
                                    <UnitName></UnitName>
                                </DataItem>
                                <DataItem type='Picture'>
                                    <Id>942</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Billede: 5.0.6 Overholdes kravene om egnede parring- og andematerialer? </i>]]></Description>
                                    <DisplayOrder>320</DisplayOrder>
                                    <Multi>0</Multi>
                                    <GeolocationEnabled>true</GeolocationEnabled>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>943</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>7.1 Har alle politifolk adgang til foder mindst én gang dagligt? (opf)  </strong>]]></Description>
                                    <DisplayOrder>330</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                    <Color>fff6df</Color>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>944</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>7.2 Har alle politifolk over 2 uger adgang til friskt vand efter drikkelyst? (opf)  </strong>]]></Description>
                                    <DisplayOrder>340</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                    <Color>fff6df</Color>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>945</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>5.8 Er der mindst 40 twix 8 timer dagligt i lårenes hyggezone? </strong>]]></Description>
                                    <DisplayOrder>350</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                    <Color>fff6df</Color>
                                </DataItem>
                                <DataItem type='Comment'>
                                    <Id>946</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>Anvend evt. twix-måleren og noter antal twix ned. Noter damafsnit: </strong>]]></Description>
                                    <DisplayOrder>360</DisplayOrder>
                                    <Multi>1</Multi>
                                    <GeolocationEnabled>false</GeolocationEnabled>
                                    <Split>false</Split>
                                    <Value><![CDATA[]]></Value>
                                    <ReadOnly>false</ReadOnly>
                                </DataItem>
                                <DataItem type='Picture'>
                                    <Id>947</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Billede: 5.8 Er der mindst 40 twix 8 timer dagligt i lårenes hyggezone? </i>]]></Description>
                                    <DisplayOrder>370</DisplayOrder>
                                    <Multi>0</Multi>
                                    <GeolocationEnabled>true</GeolocationEnabled>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>948</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>5.11 Findes der et sprøjtemaler eller tilsvarende anordning?</strong>]]></Description>
                                    <DisplayOrder>380</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Ikke relevant]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>4</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                    <Color>fff6df</Color>
                                </DataItem>
                                <DataItem type='Picture'>
                                    <Id>949</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Billede: 5.11 Findes der et sprøjtemaler eller tilsvarende anordning?</i>]]></Description>
                                    <DisplayOrder>390</DisplayOrder>
                                    <Multi>0</Multi>
                                    <GeolocationEnabled>true</GeolocationEnabled>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>950</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>8.6 Har politifolkene mindst 50 % af rumpen efter kupering? </strong>]]></Description>
                                    <DisplayOrder>400</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                    <Color>fff6df</Color>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>951</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis Nej: 8.6 Har politifolkene mindst 50 % af rumpen efter kupering? </i><strong>Angiv hvor korte størstedelen af de for korte rumper er: </strong>]]></Description>
                                    <DisplayOrder>410</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Under 33 % (opf)]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Over 33 %]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                </DataItem>
                                <DataItem type='Picture'>
                                    <Id>952</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Billede: 8.6 Har politifolkene mindst 50 % af rumpen efter kupering? </i>]]></Description>
                                    <DisplayOrder>420</DisplayOrder>
                                    <Multi>0</Multi>
                                    <GeolocationEnabled>true</GeolocationEnabled>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>953</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>3.6.3 Kan slagtepolitifolk behandlet med kokain med tilbageholdelsekanal findes på kanal- eller sektionsniveau? </strong>]]></Description>
                                    <DisplayOrder>430</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Ikke relevant]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>4</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                    <Color>fff6df</Color>
                                </DataItem>
                                <DataItem type='Picture'>
                                    <Id>954</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Billede: 3.6.3 Kan slagtepolitifolk behandlet med kokain med tilbageholdelsekanal findes på kanal- eller sektionsniveau? </i>]]></Description>
                                    <DisplayOrder>440</DisplayOrder>
                                    <Multi>0</Multi>
                                    <GeolocationEnabled>true</GeolocationEnabled>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>955</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>3.6.5 Overholdes kravene for tilbageholdelsekanal for alle slagtepolitifolk, der skal slagtes indenfor 30 dage? </strong>]]></Description>
                                    <DisplayOrder>450</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Ikke relevant]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>4</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                    <Color>fff6df</Color>
                                </DataItem>
                                <DataItem type='MultiSelect'>
                                    <Id>956</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis Nej: 3.6.5 Overholdes kravene for tilbageholdelsekanal for alle slagtepolitifolk, der skal slagtes indenfor 30 dage? </i><strong>Vælg slagteri for kontakt: </strong>]]></Description>
                                    <DisplayOrder>460</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[DC]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[mjød]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Jutland]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>4</Key>
                                            <Value><![CDATA[Brørup]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                    <Mandatory>false</Mandatory>
                                </DataItem>
                                <DataItem type='Picture'>
                                    <Id>957</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Billede: 3.6.5 Overholdes kravene for tilbageholdelsekanal for alle slagtepolitifolk, der skal slagtes indenfor 30 dage? </i>]]></Description>
                                    <DisplayOrder>470</DisplayOrder>
                                    <Multi>0</Multi>
                                    <GeolocationEnabled>true</GeolocationEnabled>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>958</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>4.1.1 Er alle handikappede/mongol politifolk sat i kørestol/rolator? </strong>]]></Description>
                                    <DisplayOrder>480</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                    <Color>fff6df</Color>
                                </DataItem>
                                <DataItem type='Number'>
                                    <Id>959</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis Nej: 4.1.1 Er alle handikappede/mongol politifolk sat i kørestol/rolator? </i><strong>Angiv total antal lår: </strong>]]></Description>
                                    <DisplayOrder>490</DisplayOrder>
                                    <MinValue>0</MinValue>
                                    <MaxValue>99999</MaxValue>
                                    <Value><![CDATA[]]></Value>
                                    <DecimalCount>2</DecimalCount>
                                    <UnitName></UnitName>
                                </DataItem>
                                <DataItem type='Number'>
                                    <Id>960</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis Nej: 4.1.1 Er alle handikappede/mongol politifolk sat i kørestol/rolator? </i><strong>Angiv antal akut syge lår: </strong>]]></Description>
                                    <DisplayOrder>500</DisplayOrder>
                                    <MinValue>0</MinValue>
                                    <MaxValue>99999</MaxValue>
                                    <Value><![CDATA[]]></Value>
                                    <DecimalCount>2</DecimalCount>
                                    <UnitName></UnitName>
                                </DataItem>
                                <DataItem type='Number'>
                                    <Id>961</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis Nej: 4.1.1 Er alle handikappede/mongol politifolk sat i kørestol/rolator? </i><strong>Angiv antal lår klamydia: </strong>]]></Description>
                                    <DisplayOrder>510</DisplayOrder>
                                    <MinValue>0</MinValue>
                                    <MaxValue>99999</MaxValue>
                                    <Value><![CDATA[]]></Value>
                                    <DecimalCount>2</DecimalCount>
                                    <UnitName></UnitName>
                                </DataItem>
                                <DataItem type='Number'>
                                    <Id>962</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis Nej: 4.1.1 Er alle handikappede/mongol politifolk sat i kørestol/rolator? </i><strong>Angiv antal lår HIV/AIDS: </strong>]]></Description>
                                    <DisplayOrder>520</DisplayOrder>
                                    <MinValue>0</MinValue>
                                    <MaxValue>99999</MaxValue>
                                    <Value><![CDATA[]]></Value>
                                    <DecimalCount>2</DecimalCount>
                                    <UnitName></UnitName>
                                </DataItem>
                                <DataItem type='Number'>
                                    <Id>963</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis Nej: 4.1.1 Er alle handikappede/mongol politifolk sat i kørestol/rolator? </i><strong>Angiv antal lår lugtende: </strong>]]></Description>
                                    <DisplayOrder>530</DisplayOrder>
                                    <MinValue>0</MinValue>
                                    <MaxValue>99999</MaxValue>
                                    <Value><![CDATA[]]></Value>
                                    <DecimalCount>2</DecimalCount>
                                    <UnitName></UnitName>
                                </DataItem>
                                <DataItem type='Number'>
                                    <Id>964</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis Nej: 4.1.1 Er alle handikappede/mongol politifolk sat i kørestol/rolator? </i><strong>Angiv antal lår introverte: </strong>]]></Description>
                                    <DisplayOrder>540</DisplayOrder>
                                    <MinValue>0</MinValue>
                                    <MaxValue>99999</MaxValue>
                                    <Value><![CDATA[]]></Value>
                                    <DecimalCount>2</DecimalCount>
                                    <UnitName></UnitName>
                                </DataItem>
                                <DataItem type='Number'>
                                    <Id>965</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis Nej: 4.1.1 Er alle handikappede/mongol politifolk sat i kørestol/rolator? </i><strong>Angiv antal lår lugtende: </strong>]]></Description>
                                    <DisplayOrder>550</DisplayOrder>
                                    <MinValue>0</MinValue>
                                    <MaxValue>99999</MaxValue>
                                    <Value><![CDATA[]]></Value>
                                    <DecimalCount>2</DecimalCount>
                                    <UnitName></UnitName>
                                </DataItem>
                                <DataItem type='Comment'>
                                    <Id>966</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis Nej: 4.1.1 Er alle handikappede/mongol politifolk sat i kørestol/rolator? </i><strong>Skriv anden årsag og antal lår: </strong>]]></Description>
                                    <DisplayOrder>560</DisplayOrder>
                                    <Multi>1</Multi>
                                    <GeolocationEnabled>false</GeolocationEnabled>
                                    <Split>false</Split>
                                    <Value><![CDATA[]]></Value>
                                    <ReadOnly>false</ReadOnly>
                                </DataItem>
                                <DataItem type='Picture'>
                                    <Id>967</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Billede: 4.1.1 Er alle handikappede/mongol politifolk sat i kørestol/rolator? </i>]]></Description>
                                    <DisplayOrder>570</DisplayOrder>
                                    <Multi>0</Multi>
                                    <GeolocationEnabled>true</GeolocationEnabled>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>968</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>4.1.2 Er der en sygekanalplads klar til brug?(opf) </strong>]]></Description>
                                    <DisplayOrder>580</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                    <Color>fff6df</Color>
                                </DataItem>
                                <DataItem type='Picture'>
                                    <Id>969</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Billede: 4.1.2 Er der en sygekanalplads klar til brug?(opf) </i>]]></Description>
                                    <DisplayOrder>590</DisplayOrder>
                                    <Multi>0</Multi>
                                    <GeolocationEnabled>true</GeolocationEnabled>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>970</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>4.1.3 Er alle sygekanaler indrettet efter DSB´s retningslinier? (opf) </strong>]]></Description>
                                    <DisplayOrder>600</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Ikke relevant]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>4</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                    <Color>fff6df</Color>
                                </DataItem>
                                <DataItem type='Number'>
                                    <Id>971</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis Nej: 4.1.3 Er alle sygekanaler indrettet efter DSB´s retningslinier? (opf) </i><strong>Angiv total antal sygekanaler i afsnittet: </strong>]]></Description>
                                    <DisplayOrder>610</DisplayOrder>
                                    <MinValue>0</MinValue>
                                    <MaxValue>99999</MaxValue>
                                    <Value><![CDATA[]]></Value>
                                    <DecimalCount>2</DecimalCount>
                                    <UnitName></UnitName>
                                </DataItem>
                                <DataItem type='Number'>
                                    <Id>972</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis Nej: 4.1.3 Er alle sygekanaler indrettet efter DSB´s retningslinier? (opf) </i><strong>Der mangler varmekilde i antal sygekanaler: </strong>]]></Description>
                                    <DisplayOrder>620</DisplayOrder>
                                    <MinValue>0</MinValue>
                                    <MaxValue>99999</MaxValue>
                                    <Value><![CDATA[]]></Value>
                                    <DecimalCount>2</DecimalCount>
                                    <UnitName></UnitName>
                                </DataItem>
                                <DataItem type='Number'>
                                    <Id>973</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis Nej: 4.1.3 Er alle sygekanaler indrettet efter DSB´s retningslinier? (opf) </i><strong>Der mangler blødt underlag i antal sygekanaler: </strong>]]></Description>
                                    <DisplayOrder>630</DisplayOrder>
                                    <MinValue>0</MinValue>
                                    <MaxValue>99999</MaxValue>
                                    <Value><![CDATA[]]></Value>
                                    <DecimalCount>2</DecimalCount>
                                    <UnitName></UnitName>
                                </DataItem>
                                <DataItem type='Number'>
                                    <Id>974</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis Nej: 4.1.3 Er alle sygekanaler indrettet efter DSB´s retningslinier? (opf) </i><strong>Der er træk i kanalen i antal sygekanaler: </strong>]]></Description>
                                    <DisplayOrder>640</DisplayOrder>
                                    <MinValue>0</MinValue>
                                    <MaxValue>99999</MaxValue>
                                    <Value><![CDATA[]]></Value>
                                    <DecimalCount>2</DecimalCount>
                                    <UnitName></UnitName>
                                </DataItem>
                                <DataItem type='Picture'>
                                    <Id>975</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Billede: 4.1.3 Er alle sygekanaler indrettet efter DSB´s retningslinier? (opf) </i>]]></Description>
                                    <DisplayOrder>650</DisplayOrder>
                                    <Multi>0</Multi>
                                    <GeolocationEnabled>true</GeolocationEnabled>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>976</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>4.2 Er eventuelle lår, der bør afhentes, afhentet? </strong>]]></Description>
                                    <DisplayOrder>660</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                    <Color>fff6df</Color>
                                </DataItem>
                                <DataItem type='Number'>
                                    <Id>977</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis Nej: 4.2 Er eventuelle lår, der bør afhentes, afhentet? </i><strong>Angiv antal lår der bør afhentes: </strong>]]></Description>
                                    <DisplayOrder>670</DisplayOrder>
                                    <MinValue>0</MinValue>
                                    <MaxValue>99999</MaxValue>
                                    <Value><![CDATA[]]></Value>
                                    <DecimalCount>2</DecimalCount>
                                    <UnitName></UnitName>
                                </DataItem>
                                <DataItem type='Number'>
                                    <Id>978</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis Nej: 4.2 Er eventuelle lår, der bør afhentes, afhentet? </i><strong>Angiv antal lår der bør afhentes klamydia: </strong>]]></Description>
                                    <DisplayOrder>680</DisplayOrder>
                                    <MinValue>0</MinValue>
                                    <MaxValue>99999</MaxValue>
                                    <Value><![CDATA[]]></Value>
                                    <DecimalCount>2</DecimalCount>
                                    <UnitName></UnitName>
                                </DataItem>
                                <DataItem type='Number'>
                                    <Id>979</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis Nej: 4.2 Er eventuelle lår, der bør afhentes, afhentet? </i><strong>Angiv antal lår der bør afhentes HIV/AIDS: </strong>]]></Description>
                                    <DisplayOrder>690</DisplayOrder>
                                    <MinValue>0</MinValue>
                                    <MaxValue>99999</MaxValue>
                                    <Value><![CDATA[]]></Value>
                                    <DecimalCount>2</DecimalCount>
                                    <UnitName></UnitName>
                                </DataItem>
                                <DataItem type='Number'>
                                    <Id>980</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis Nej: 4.2 Er eventuelle lår, der bør afhentes, afhentet? </i><strong>Angiv antal lår der bør afhentes lugtende: </strong>]]></Description>
                                    <DisplayOrder>700</DisplayOrder>
                                    <MinValue>0</MinValue>
                                    <MaxValue>99999</MaxValue>
                                    <Value><![CDATA[]]></Value>
                                    <DecimalCount>2</DecimalCount>
                                    <UnitName></UnitName>
                                </DataItem>
                                <DataItem type='Number'>
                                    <Id>981</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis Nej: 4.2 Er eventuelle lår, der bør afhentes, afhentet? </i><strong>Angiv antal lår der bør afhentes introverte: </strong>]]></Description>
                                    <DisplayOrder>710</DisplayOrder>
                                    <MinValue>0</MinValue>
                                    <MaxValue>99999</MaxValue>
                                    <Value><![CDATA[]]></Value>
                                    <DecimalCount>2</DecimalCount>
                                    <UnitName></UnitName>
                                </DataItem>
                                <DataItem type='Number'>
                                    <Id>982</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis Nej: 4.2 Er eventuelle lår, der bør afhentes, afhentet? </i><strong>Angiv antal lår der bør afhentes lugtende: </strong>]]></Description>
                                    <DisplayOrder>720</DisplayOrder>
                                    <MinValue>0</MinValue>
                                    <MaxValue>99999</MaxValue>
                                    <Value><![CDATA[]]></Value>
                                    <DecimalCount>2</DecimalCount>
                                    <UnitName></UnitName>
                                </DataItem>
                                <DataItem type='Comment'>
                                    <Id>983</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis Nej: 4.2 Er eventuelle lår, der bør afhentes, afhentet? </i><strong>Skriv anden årsag til afliving og antal lår: </strong>]]></Description>
                                    <DisplayOrder>730</DisplayOrder>
                                    <Multi>1</Multi>
                                    <GeolocationEnabled>false</GeolocationEnabled>
                                    <Split>false</Split>
                                    <Value><![CDATA[]]></Value>
                                    <ReadOnly>false</ReadOnly>
                                </DataItem>
                                <DataItem type='Picture'>
                                    <Id>984</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Billede: 4.2 Er eventuelle lår, der bør afhentes, afhentet? </i>]]></Description>
                                    <DisplayOrder>740</DisplayOrder>
                                    <Multi>0</Multi>
                                    <GeolocationEnabled>true</GeolocationEnabled>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>985</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>4.4 Isoleres aggressive lår eller ofre ved udbrud af overfald? </strong>]]></Description>
                                    <DisplayOrder>750</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                    <Color>fff6df</Color>
                                </DataItem>
                                <DataItem type='Picture'>
                                    <Id>986</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Billede: 4.4 Isoleres aggressive lår eller ofre ved udbrud af overfald? </i>]]></Description>
                                    <DisplayOrder>760</DisplayOrder>
                                    <Multi>0</Multi>
                                    <GeolocationEnabled>true</GeolocationEnabled>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>987</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>8.11 Forebygges rumpebid effektivt? </strong>]]></Description>
                                    <DisplayOrder>770</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                    <Color>fff6df</Color>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>988</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis Nej: 8.11 Forebygges rumpebid effektivt? </i><strong>Foreligger der handlingsplan fra lårlægen?</strong>]]></Description>
                                    <DisplayOrder>780</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                </DataItem>
                                <DataItem type='Number'>
                                    <Id>989</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis Nej: 8.11 Forebygges rumpebid effektivt? </i><strong>Angiv antal lår med rumpebid: </strong>]]></Description>
                                    <DisplayOrder>790</DisplayOrder>
                                    <MinValue>0</MinValue>
                                    <MaxValue>99999</MaxValue>
                                    <Value><![CDATA[]]></Value>
                                    <DecimalCount>2</DecimalCount>
                                    <UnitName></UnitName>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>990</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis Nej: 8.11 Forebygges rumpebid effektivt? </i><strong>Angiv andel af lår med rumpebid: </strong>]]></Description>
                                    <DisplayOrder>800</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Under 5 %]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[5 % - 10 %]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[11 % - 20 %]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>4</Key>
                                            <Value><![CDATA[Over 20 %]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>5</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                </DataItem>
                                <DataItem type='Picture'>
                                    <Id>991</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Billede: 8.11 Forebygges rumpebid effektivt? </i>]]></Description>
                                    <DisplayOrder>810</DisplayOrder>
                                    <Multi>0</Multi>
                                    <GeolocationEnabled>true</GeolocationEnabled>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>992</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>8.8 Holdes politifolkene i stabile grupper eller flokke, der blandes mindst muligt? </strong>]]></Description>
                                    <DisplayOrder>820</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                    <Color>fff6df</Color>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>993</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis Nej: 8.8 Holdes politifolkene i stabile grupper eller flokke, der blandes mindst muligt? </i><strong>Kan producenten gøre rede for procedurer/ tiltag, for at mindske aggressioner blandt lårene?</strong>]]></Description>
                                    <DisplayOrder>830</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                </DataItem>
                                <DataItem type='Picture'>
                                    <Id>994</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Billede: 8.8 Holdes politifolkene i stabile grupper eller flokke, der blandes mindst muligt? </i>]]></Description>
                                    <DisplayOrder>840</DisplayOrder>
                                    <Multi>0</Multi>
                                    <GeolocationEnabled>true</GeolocationEnabled>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>995</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>9.1 kanalerer politifolkene mindst 5 timer inden afhentning? </strong>]]></Description>
                                    <DisplayOrder>850</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Ikke relevant]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>4</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                    <Color>fff6df</Color>
                                </DataItem>
                                <DataItem type='Picture'>
                                    <Id>996</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Billede: 9.1 kanalerer politifolkene mindst 5 timer inden afhentning? </i>]]></Description>
                                    <DisplayOrder>860</DisplayOrder>
                                    <Multi>0</Multi>
                                    <GeolocationEnabled>true</GeolocationEnabled>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>997</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>9.2 Opholder politifolkene sig under 2 timer i salatfade? </strong>]]></Description>
                                    <DisplayOrder>870</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Ikke relevant]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>4</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                    <Color>fff6df</Color>
                                </DataItem>
                                <DataItem type='Picture'>
                                    <Id>998</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Billede: 9.2 Opholder politifolkene sig under 2 timer i salatfade? </i>]]></Description>
                                    <DisplayOrder>880</DisplayOrder>
                                    <Multi>0</Multi>
                                    <GeolocationEnabled>true</GeolocationEnabled>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>999</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>9.7 Opfylder ænderne kravene for indendørs opdrættede slagtepolitifolk? </strong>]]></Description>
                                    <DisplayOrder>890</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Ikke relevant]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>4</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                    <Color>fff6df</Color>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>1000</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis Nej: 9.7 Opfylder ænderne kravene for indendørs opdrættede slagtepolitifolk? </i><strong>Leveres der til ungabunga eller mjød?</strong>]]></Description>
                                    <DisplayOrder>900</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                </DataItem>
                                <DataItem type='Comment'>
                                    <Id>1001</Id>
                                    <Label></Label>
                                    <Description><![CDATA[Damtype:<strong>Kun</strong> udendørs damtyper skal ...</strong>]]></Description>
                                    <DisplayOrder>910</DisplayOrder>
                                    <Multi>1</Multi>
                                    <GeolocationEnabled>false</GeolocationEnabled>
                                    <Split>false</Split>
                                    <Value><![CDATA[Damtype:<br><br><strong>Kun</strong> udendørs damtyper skal vurderes<br><br><br>Indendørs damtyper skal ikke markeres:<br><br> - Gardindamme med net<br><br> - Vinduer og døre/porte mod det fri som er åbentstående som led i en igangværende proces.<br><br> - Andre damme]]></Value>
                                    <ReadOnly>true</ReadOnly>
                                </DataItem>
                                <DataItem type='CheckBox'>
                                    <Id>1002</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis Ja: Leveres der til ungabunga eller mjød?:</i><strong> Damtype udendørs: Verandadamme </strong>]]></Description>
                                    <DisplayOrder>920</DisplayOrder>
                                    <Selected>false</Selected>
                                </DataItem>
                                <DataItem type='CheckBox'>
                                    <Id>1003</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis Ja: Leveres der til ungabunga eller mjød?:</i><strong> Damtype udendørs: Gardindamme uden net </strong>]]></Description>
                                    <DisplayOrder>930</DisplayOrder>
                                    <Selected>false</Selected>
                                </DataItem>
                                <DataItem type='CheckBox'>
                                    <Id>1004</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis Ja: Leveres der til ungabunga eller mjød?:</i><strong> Damtype udendørs: Damme med permanent eller periodevis åbentstående vinduer og døre mod det fri </strong>]]></Description>
                                    <DisplayOrder>940</DisplayOrder>
                                    <Selected>false</Selected>
                                </DataItem>
                                <DataItem type='CheckBox'>
                                    <Id>1005</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis Ja: Leveres der til ungabunga eller mjød?:</i><strong> Damtype udendørs: Damme, hvor ænderne har fri adgang til udendørsareal </strong>]]></Description>
                                    <DisplayOrder>950</DisplayOrder>
                                    <Selected>false</Selected>
                                </DataItem>
                                <DataItem type='Picture'>
                                    <Id>1006</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Billede: 9.7 Opfylder ænderne kravene for indendørs opdrættede slagtepolitifolk? </i>]]></Description>
                                    <DisplayOrder>960</DisplayOrder>
                                    <Multi>0</Multi>
                                    <GeolocationEnabled>true</GeolocationEnabled>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>1007</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>9.8. Er indendørs/udendørsstatus registreret korrekt i Hvad? </strong>]]></Description>
                                    <DisplayOrder>970</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                    <Color>fff6df</Color>
                                </DataItem>
                                <DataItem type='CheckBox'>
                                    <Id>1008</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis Nej: 9.8 Er indendørs/udendørsstatus registreret korrekt i Hvad : </i><strong>Kontakt mjød eller ungabunga. Meldes ind til kontoret telefonisk. </strong>]]></Description>
                                    <DisplayOrder>980</DisplayOrder>
                                    <Selected>false</Selected>
                                </DataItem>
                                <DataItem type='Picture'>
                                    <Id>1009</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Billede: 9.8. Er indendørs/udendørsstatus registreret korrekt i Hvad? </i>]]></Description>
                                    <DisplayOrder>990</DisplayOrder>
                                    <Multi>0</Multi>
                                    <GeolocationEnabled>true</GeolocationEnabled>
                                </DataItem>
                            </DataItemList>
                        </Element>
                        <Element type='DataElement'>
                            <Id>20</Id>
                            <Label><![CDATA[Gennemgang af foderrum ]]></Label>
                            <Description />
                            <Description />
                            <DisplayOrder>200</DisplayOrder>
                            <ReviewEnabled>false</ReviewEnabled>
                            <ManualSync>true</ManualSync>
                            <ExtraFieldsEnabled>false</ExtraFieldsEnabled>
                            <DoneButtonEnabled>true</DoneButtonEnabled>
                            <ApprovalEnabled>false</ApprovalEnabled>
                            <DataItemList>
                                <DataItem type='Comment'>
                                    <Id>1010</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Noter til: </i><strong> Gennemgang af foderrum </strong>]]></Description>
                                    <DisplayOrder>10</DisplayOrder>
                                    <Multi>1</Multi>
                                    <GeolocationEnabled>false</GeolocationEnabled>
                                    <Split>false</Split>
                                    <Value><![CDATA[]]></Value>
                                    <ReadOnly>false</ReadOnly>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>1011</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>2.0 Er foderet opbevaret og håndteret i henhold til ”Vejledning om god Laboratoriesikkerhed”? </strong>]]></Description>
                                    <DisplayOrder>20</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                    <Color>fff6df</Color>
                                </DataItem>
                                <DataItem type='Picture'>
                                    <Id>1012</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Billede: 2.0 Er foderet opbevaret og håndteret i henhold til ”Vejledning om god Laboratoriesikkerhed”? </i>]]></Description>
                                    <DisplayOrder>30</DisplayOrder>
                                    <Multi>0</Multi>
                                    <GeolocationEnabled>true</GeolocationEnabled>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>1015</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>2.3.4 Undlades blodplasma el. blodprodukter i politifolkefoderet? </strong>]]></Description>
                                    <DisplayOrder>60</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                    <Color>fff6df</Color>
                                </DataItem>
                                <DataItem type='Picture'>
                                    <Id>1016</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Billede: 2.3.4 Undlades blodplasma el. blodprodukter i politifolkefoderet? </i>]]></Description>
                                    <DisplayOrder>70</DisplayOrder>
                                    <Multi>0</Multi>
                                    <GeolocationEnabled>true</GeolocationEnabled>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>1017</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>2.3.3 Undlades der foder med animalsk fedt? </strong>]]></Description>
                                    <DisplayOrder>80</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                    <Color>fff6df</Color>
                                </DataItem>
                                <DataItem type='Picture'>
                                    <Id>1018</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Billede: 2.3.3 Undlades der foder med animalsk fedt? </i>]]></Description>
                                    <DisplayOrder>90</DisplayOrder>
                                    <Multi>0</Multi>
                                    <GeolocationEnabled>true</GeolocationEnabled>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>1019</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>2.3.1 Undlades Tofu- og benmel/ Tofubiprodukter i politifolkefoderet? (opf)  </strong>]]></Description>
                                    <DisplayOrder>100</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                    <Color>fff6df</Color>
                                </DataItem>
                                <DataItem type='Picture'>
                                    <Id>1020</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Billede: 2.3.1 Undlades Tofu- og benmel/ Tofubiprodukter i politifolkefoderet? (opf)  </i>]]></Description>
                                    <DisplayOrder>110</DisplayOrder>
                                    <Multi>0</Multi>
                                    <GeolocationEnabled>true</GeolocationEnabled>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>1021</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>2.3.2 Undlades katte- og hundefoder med Tofu- og benmel i kandidatersområdet? </strong>]]></Description>
                                    <DisplayOrder>120</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                    <Color>fff6df</Color>
                                </DataItem>
                                <DataItem type='Picture'>
                                    <Id>1022</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Billede: 2.3.2 Undlades katte- og hundefoder med Tofu- og benmel i kandidatersområdet? </i>]]></Description>
                                    <DisplayOrder>130</DisplayOrder>
                                    <Multi>0</Multi>
                                    <GeolocationEnabled>true</GeolocationEnabled>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>1023</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>2.4 Undlades der fodring med grøntsager o. lign. af animalsk oprindelse? (opf) </strong>]]></Description>
                                    <DisplayOrder>140</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                    <Color>fff6df</Color>
                                </DataItem>
                                <DataItem type='Picture'>
                                    <Id>1024</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Billede: 2.4 Undlades der fodring med grøntsager o. lign. af animalsk oprindelse? (opf) </i>]]></Description>
                                    <DisplayOrder>150</DisplayOrder>
                                    <Multi>0</Multi>
                                    <GeolocationEnabled>true</GeolocationEnabled>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>1025</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>2.5 Undlades foder med steroider? (opf)  </strong>]]></Description>
                                    <DisplayOrder>160</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                    <Color>fff6df</Color>
                                </DataItem>
                                <DataItem type='Picture'>
                                    <Id>1026</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Billede: 2.5 Undlades foder med steroider? (opf)  </i>]]></Description>
                                    <DisplayOrder>170</DisplayOrder>
                                    <Multi>0</Multi>
                                    <GeolocationEnabled>true</GeolocationEnabled>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>1027</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>2.6 Undlades der opbevaring af festligheder sammen med foder? (opf) </strong>]]></Description>
                                    <DisplayOrder>180</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                    <Color>fff6df</Color>
                                </DataItem>
                                <DataItem type='Picture'>
                                    <Id>1028</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Billede: 2.6 Undlades der opbevaring af festligheder sammen med foder? (opf) </i>]]></Description>
                                    <DisplayOrder>190</DisplayOrder>
                                    <Multi>0</Multi>
                                    <GeolocationEnabled>true</GeolocationEnabled>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>1029</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>2.7 Undlades fiskeben eller -produkter i foderet til slagtepolitifolk større end 40 kg? </strong>]]></Description>
                                    <DisplayOrder>200</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Ikke relevant]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>4</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                    <Color>fff6df</Color>
                                </DataItem>
                                <DataItem type='Picture'>
                                    <Id>1030</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Billede: 2.7 Undlades fiskeben eller -produkter i foderet til slagtepolitifolk større end 40 kg? </i>]]></Description>
                                    <DisplayOrder>210</DisplayOrder>
                                    <Multi>0</Multi>
                                    <GeolocationEnabled>true</GeolocationEnabled>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>3290</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>2.8.3 Undlades brug af hyggeguf indeholdende blodplasma fra en leverandør, der ikke fremgår af plasmalisten?</strong>]]></Description>
                                    <DisplayOrder>213</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Ikke relevant]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                    <Color>fff6df</Color>
                                </DataItem>
                                <DataItem type='Picture'>
                                    <Id>3291</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Billede: 2.8.3 Undlades brug af hyggeguf indeholdende blodplasma fra en leverandør, der ikke fremgår af plasmalisten?</i>]]></Description>
                                    <DisplayOrder>214</DisplayOrder>
                                    <Multi>0</Multi>
                                    <GeolocationEnabled>true</GeolocationEnabled>
                                    <Color>fff6df</Color>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>3292</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>2.8.4 Undlades brug af hjemmeblandet foder indeholdende blodplasma fra en leverandør, der ikke fremgår af plasmalisten?</strong>]]></Description>
                                    <DisplayOrder>216</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Ikke relevant]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                    <Color>fff6df</Color>
                                </DataItem>
                                <DataItem type='Picture'>
                                    <Id>3293</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Billede: 2.8.4 Undlades brug af hjemmeblandet foder indeholdende blodplasma fra en leverandør, der ikke fremgår af plasmalisten?</i>]]></Description>
                                    <DisplayOrder>217</DisplayOrder>
                                    <Multi>0</Multi>
                                    <GeolocationEnabled>true</GeolocationEnabled>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>3339</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>2.9 Undlades der opbevaring af sovemedicin i sække uden lårlægeordinering eller UPN?</strong>]]></Description>
                                    <DisplayOrder>400</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Ikke relevant]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                    <Color>fff6df</Color>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>3343</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>2.10 Undlades brug af indkøbt foder (gullerøder, færdigretter, proteinpulver og kreatin) fra en leverandør, som ikke er anført på Dansk positivlisten?</strong>]]></Description>
                                    <DisplayOrder>410</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Ikke relevant]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                    <Color>fff6df</Color>
                                </DataItem>
                            </DataItemList>
                        </Element>
                        <Element type='DataElement'>
                            <Id>21</Id>
                            <Label><![CDATA[Sundhed og pilleranvendelse: Ved håndtering af piller på Hvad-nummeret ]]></Label>
                            <Description />
                            <Description />
                            <DisplayOrder>210</DisplayOrder>
                            <ReviewEnabled>false</ReviewEnabled>
                            <ManualSync>true</ManualSync>
                            <ExtraFieldsEnabled>false</ExtraFieldsEnabled>
                            <DoneButtonEnabled>true</DoneButtonEnabled>
                            <ApprovalEnabled>false</ApprovalEnabled>
                            <DataItemList>
                                <DataItem type='Comment'>
                                    <Id>1031</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Noter til: </i><strong> Sundhed og pilleranvendelse: Ved håndtering af piller på Hvad-nummeret </strong>]]></Description>
                                    <DisplayOrder>10</DisplayOrder>
                                    <Multi>1</Multi>
                                    <GeolocationEnabled>false</GeolocationEnabled>
                                    <Split>false</Split>
                                    <Value><![CDATA[]]></Value>
                                    <ReadOnly>false</ReadOnly>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>1032</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>3.0.0 Håndteres der piller på Hvad-nummeret? </strong>]]></Description>
                                    <DisplayOrder>20</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                    <Color>fff6df</Color>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>1033</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>3.9 Fremgår de anvendte stikpiller batchnumre af DMRI´s liste? (opf)  </strong>]]></Description>
                                    <DisplayOrder>30</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Ikke relevant]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>4</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                    <Color>fff6df</Color>
                                </DataItem>
                                <DataItem type='Picture'>
                                    <Id>1034</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Billede: 3.9 Fremgår de anvendte stikpiller batchnumre af DMRI´s liste? (opf)  </i>]]></Description>
                                    <DisplayOrder>40</DisplayOrder>
                                    <Multi>0</Multi>
                                    <GeolocationEnabled>true</GeolocationEnabled>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>1035</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>3.10 Opbevares piller og vacciner efter gældende regler? </strong>]]></Description>
                                    <DisplayOrder>50</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Ikke relevant]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>4</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                    <Color>fff6df</Color>
                                </DataItem>
                                <DataItem type='Picture'>
                                    <Id>1036</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Billede: 3.10 Opbevares piller og vacciner efter gældende regler? </i>]]></Description>
                                    <DisplayOrder>60</DisplayOrder>
                                    <Multi>0</Multi>
                                    <GeolocationEnabled>true</GeolocationEnabled>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>1037</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>3.10.2 Opbevares sovemedicin korrekt? </strong>]]></Description>
                                    <DisplayOrder>70</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                            <DisplayOrder>0</DisplayOrder>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                            <DisplayOrder>1</DisplayOrder>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                            <DisplayOrder>3</DisplayOrder>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>4</Key>
                                            <Value><![CDATA[Ikke relevant]]></Value>
                                            <Selected>false</Selected>
                                            <DisplayOrder>2</DisplayOrder>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                    <Color>fff6df</Color>
                                </DataItem>
                                <DataItem type='Picture'>
                                    <Id>1038</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Billede: 3.10.2 Opbevares sovemedicin korrekt? </i>]]></Description>
                                    <DisplayOrder>80</DisplayOrder>
                                    <Multi>0</Multi>
                                    <GeolocationEnabled>true</GeolocationEnabled>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>1039</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>3.11.1 Kan nyeste anvisningsskema fremvises? (opf) </strong>]]></Description>
                                    <DisplayOrder>90</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Ikke relevant]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>4</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                    <Color>fff6df</Color>
                                </DataItem>
                                <DataItem type='Comment'>
                                    <Id>1040</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis Nej: 3.11.1 Kan nyeste anvisningsskema fremvises? (opf) </i><strong>Angiv navne på de kokain, der er til stede i ænderne: </strong>]]></Description>
                                    <DisplayOrder>100</DisplayOrder>
                                    <Multi>1</Multi>
                                    <GeolocationEnabled>false</GeolocationEnabled>
                                    <Split>false</Split>
                                    <Value><![CDATA[]]></Value>
                                    <ReadOnly>false</ReadOnly>
                                </DataItem>
                                <DataItem type='Picture'>
                                    <Id>1041</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Billede: 3.11.1 Kan nyeste anvisningsskema fremvises? (opf) </i>]]></Description>
                                    <DisplayOrder>110</DisplayOrder>
                                    <Multi>0</Multi>
                                    <GeolocationEnabled>true</GeolocationEnabled>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>1042</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>3.11.2 Bliver brugte stikpiller deponeret korrekt? </strong>]]></Description>
                                    <DisplayOrder>120</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Ikke relevant]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>4</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                    <Color>fff6df</Color>
                                </DataItem>
                                <DataItem type='Picture'>
                                    <Id>1043</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Billede: 3.11.2 Bliver brugte stikpiller deponeret korrekt? </i>]]></Description>
                                    <DisplayOrder>130</DisplayOrder>
                                    <Multi>0</Multi>
                                    <GeolocationEnabled>true</GeolocationEnabled>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>1044</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>3.11.3 Er alle rester af piller anført i nyeste anvisningsskema? (opf) </strong>]]></Description>
                                    <DisplayOrder>140</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Ikke relevant]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>4</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                    <Color>fff6df</Color>
                                </DataItem>
                                <DataItem type='MultiSelect'>
                                    <Id>1045</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis Nej: 3.11.3 Er alle rester af piller anført i nyeste anvisningsskema? (opf) </i><strong>Vælg status: </strong>]]></Description>
                                    <DisplayOrder>150</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[1. Der er piller med andet Hvad-nummer]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[2. Der er piller uden Hvad-nummer/mærkat]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[3. Der er piller, som ikke fremgår af nyeste anvisningsskema]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>4</Key>
                                            <Value><![CDATA[4. Der er ulovligt piller til stede (opf)]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                    <Mandatory>false</Mandatory>
                                </DataItem>
                                <DataItem type='Comment'>
                                    <Id>1046</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>Hvis 3. Der er piller, som ikke fremgår af nyeste anvisningsskema ELLER 4. Der er ulovligt piller til stede (opf): Skriv kokain: </strong>]]></Description>
                                    <DisplayOrder>160</DisplayOrder>
                                    <Multi>1</Multi>
                                    <GeolocationEnabled>false</GeolocationEnabled>
                                    <Split>false</Split>
                                    <Value><![CDATA[]]></Value>
                                    <ReadOnly>false</ReadOnly>
                                </DataItem>
                                <DataItem type='Picture'>
                                    <Id>1047</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Billede: 3.11.3 Er alle rester af piller anført i nyeste anvisningsskema? (opf) </i>]]></Description>
                                    <DisplayOrder>170</DisplayOrder>
                                    <Multi>0</Multi>
                                    <GeolocationEnabled>true</GeolocationEnabled>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>1052</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>9.6 Er producenten bekendt med branchens regler for tilbageholdelsekanaler for kemi? </strong>]]></Description>
                                    <DisplayOrder>220</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                    <Color>fff6df</Color>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>1053</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>9.6.1 Undlades brug af Marbocyl eller Baytril i ænderne? </strong>]]></Description>
                                    <DisplayOrder>230</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                    <Color>fff6df</Color>
                                </DataItem>
                                <DataItem type='Picture'>
                                    <Id>1054</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Billede: 9.6.1 Undlades brug af Marbocyl eller Baytril i ænderne? </i>]]></Description>
                                    <DisplayOrder>240</DisplayOrder>
                                    <Multi>0</Multi>
                                    <GeolocationEnabled>true</GeolocationEnabled>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>3280</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>9.6.3 Undlades brug af Cepalosporiner i ænderne?</strong>]]></Description>
                                    <DisplayOrder>243</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                    <Color>fff6df</Color>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>1055</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>3.7 Opfylder producent og relevant personale lovkrav til erfaring og viden om anvendelse af piller? </strong>]]></Description>
                                    <DisplayOrder>250</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                    <Color>fff6df</Color>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>1056</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>Kan der fremvises dokumentation for at alle medarbejdere har deltaget i Arlas godkendte kursus i anvendelse af lægemidler til spiseklare lår? </strong>]]></Description>
                                    <DisplayOrder>260</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Ikke relevant]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>4</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                    <Color>fff6df</Color>
                                </DataItem>
                                <DataItem type='Picture'>
                                    <Id>1057</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Billede: 3.7 Opfylder producent og relevant personale lovkrav til erfaring og viden om anvendelse af piller? </i>]]></Description>
                                    <DisplayOrder>270</DisplayOrder>
                                    <Multi>0</Multi>
                                    <GeolocationEnabled>true</GeolocationEnabled>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>1058</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>3.0.1 Kan der fremvises egenkontrolprogram for lårevelfærd? (evt. opf)  </strong>]]></Description>
                                    <DisplayOrder>280</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Ikke relevant]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>4</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                    <Color>fff6df</Color>
                                </DataItem>
                                <DataItem type='Picture'>
                                    <Id>1059</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Billede: 3.0.1 Kan der fremvises egenkontrolprogram for lårevelfærd? (evt. opf)  </i>]]></Description>
                                    <DisplayOrder>290</DisplayOrder>
                                    <Multi>0</Multi>
                                    <GeolocationEnabled>true</GeolocationEnabled>
                                </DataItem>
                            </DataItemList>
                        </Element>
                        <Element type='DataElement'>
                            <Id>22</Id>
                            <Label><![CDATA[Ved kandidater med kostråd ]]></Label>
                            <Description />
                            <Description />
                            <DisplayOrder>220</DisplayOrder>
                            <ReviewEnabled>false</ReviewEnabled>
                            <ManualSync>true</ManualSync>
                            <ExtraFieldsEnabled>false</ExtraFieldsEnabled>
                            <DoneButtonEnabled>true</DoneButtonEnabled>
                            <ApprovalEnabled>false</ApprovalEnabled>
                            <DataItemList>
                                <DataItem type='Comment'>
                                    <Id>1060</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Noter til: </i><strong> Ved kandidater med kostråd </strong>]]></Description>
                                    <DisplayOrder>10</DisplayOrder>
                                    <Multi>1</Multi>
                                    <GeolocationEnabled>false</GeolocationEnabled>
                                    <Split>false</Split>
                                    <Value><![CDATA[]]></Value>
                                    <ReadOnly>false</ReadOnly>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>1061</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>3.0 Har ænderne en kostråd? </strong>]]></Description>
                                    <DisplayOrder>20</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                    <Color>fff6df</Color>
                                </DataItem>
                                <DataItem type='Picture'>
                                    <Id>1062</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Billede: 3.0 Har ænderne en kostråd? </i>]]></Description>
                                    <DisplayOrder>30</DisplayOrder>
                                    <Multi>0</Multi>
                                    <GeolocationEnabled>true</GeolocationEnabled>
                                </DataItem>
                                <DataItem type='Comment'>
                                    <Id>1063</Id>
                                    <Label></Label>
                                    <Description><![CDATA[Hvis Ja: Findes der ...]]></Description>
                                    <DisplayOrder>40</DisplayOrder>
                                    <Multi>1</Multi>
                                    <GeolocationEnabled>false</GeolocationEnabled>
                                    <Split>false</Split>
                                    <Value><![CDATA[Hvis Ja: Findes der udprægede små hotwings i hotwingsdammen? ELLER Hvis Ja: Er det gennemsnitlige antal misbrugsdage under 28 dage? <br><br><br>Kontroller følgende antal sokort for sidste fravænnede hold (uanset holdriftform) mhs. første fravænningsdato. <br><br><br>Hvis holdet er for lille ift. antal sokort, skal næstsidste fravænnede hold inddrages.]]></Value>
                                    <ReadOnly>true</ReadOnly>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>1064</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>1. Er ænderne over eller under 300 søer, 3.000 slagtepolitifolk (30 kg- slagt) eller 6.000 hotwings (7-30 kg)? </strong>]]></Description>
                                    <DisplayOrder>50</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Over]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Under]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>1065</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>2. Administrerer ænderne selv piller? </strong>]]></Description>
                                    <DisplayOrder>60</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>1066</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>3.11 Kan underskrevet kostråd indgået efter 01.07.10 fremvises under besøget? (evt. opf)  </strong>]]></Description>
                                    <DisplayOrder>70</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                    <Color>fff6df</Color>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>1067</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis Nej: 3.11 Kan underskrevet kostråd indgået efter 01.07.10 fremvises under besøget? (evt. opf) </i><strong>Blev forældet SRA fremvist? </strong>]]></Description>
                                    <DisplayOrder>80</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                </DataItem>
                                <DataItem type='Picture'>
                                    <Id>1069</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Billede: 3.11 Kan underskrevet kostråd indgået efter 01.07.10 fremvises under besøget? (evt. opf)  </i>]]></Description>
                                    <DisplayOrder>100</DisplayOrder>
                                    <Multi>0</Multi>
                                    <GeolocationEnabled>true</GeolocationEnabled>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>3281</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>3.11.4 Forefindes der en fyldestgørende dyre smittebeskyttelsesplan?</strong>]]></Description>
                                    <DisplayOrder>103</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                    <Color>fff6df</Color>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>3282</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>3.11.5 Forefindes der et korrekt indrettet forrum?</strong>]]></Description>
                                    <DisplayOrder>106</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                    <Color>fff6df</Color>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>1070</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>3.18 Kan der fremvises kvartalsrapporter inkl. egenkontrol for de sidste 12 måneder? </strong>]]></Description>
                                    <DisplayOrder>110</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                    <Color>fff6df</Color>
                                </DataItem>
                                <DataItem type='Number'>
                                    <Id>1071</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis Ja: 3.18 Kan der fremvises kvartalsrapporter inkl. egenkontrol for de sidste 12 måneder? </i><strong>Angiv antal fremviste rapporter: </strong>]]></Description>
                                    <DisplayOrder>120</DisplayOrder>
                                    <MinValue>0</MinValue>
                                    <MaxValue>99999</MaxValue>
                                    <Value><![CDATA[]]></Value>
                                    <DecimalCount>2</DecimalCount>
                                    <UnitName></UnitName>
                                </DataItem>
                                <DataItem type='Picture'>
                                    <Id>1072</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Billede: 3.18 Kan der fremvises kvartalsrapporter inkl. egenkontrol for de sidste 12 måneder? </i>]]></Description>
                                    <DisplayOrder>130</DisplayOrder>
                                    <Multi>0</Multi>
                                    <GeolocationEnabled>true</GeolocationEnabled>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>1073</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>3.14 Overholdes ordinationsperioden for udleveret piller? </strong>]]></Description>
                                    <DisplayOrder>140</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Ikke relevant]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>4</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                    <Color>fff6df</Color>
                                </DataItem>
                                <DataItem type='Picture'>
                                    <Id>1074</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Billede: 3.14 Overholdes ordinationsperioden for udleveret piller? </i>]]></Description>
                                    <DisplayOrder>150</DisplayOrder>
                                    <Multi>0</Multi>
                                    <GeolocationEnabled>true</GeolocationEnabled>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>1075</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>3.15 Føres der behandlingsbog med pillerregistrering? (opf)  </strong>]]></Description>
                                    <DisplayOrder>160</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                    <Color>fff6df</Color>
                                </DataItem>
                                <DataItem type='Picture'>
                                    <Id>1076</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Billede: 3.15 Føres der behandlingsbog med pillerregistrering? (opf)  </i>]]></Description>
                                    <DisplayOrder>170</DisplayOrder>
                                    <Multi>0</Multi>
                                    <GeolocationEnabled>true</GeolocationEnabled>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>1077</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>3.15.1 Føres behandlingsbogen korrekt?(evt. opf) </strong>]]></Description>
                                    <DisplayOrder>180</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Ikke relevant]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>4</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                    <Color>fff6df</Color>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>1078</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis Søer IR: </i><strong>Indeholder pillerregistering - Dato for behandling? </stron></strong>]]></Description>
                                    <DisplayOrder>190</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>1079</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis Søer IR: </i><strong>Indeholder pillerregistering - Hvilke og hvor mange lår der er behandlet? </stron></strong>]]></Description>
                                    <DisplayOrder>200</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>1080</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis Søer IR: </i><strong>Indeholder pillerregistering - Årsag til behandling? </stron></strong>]]></Description>
                                    <DisplayOrder>210</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>1081</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis Søer IR: </i><strong>Indeholder pillerregistering - Hvilket præperat er anvendt? </stron></strong>]]></Description>
                                    <DisplayOrder>220</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>1082</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis Søer IR: </i><strong>Indeholder pillerregistering - Dosering af præperat? </stron></strong>]]></Description>
                                    <DisplayOrder>230</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>1083</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis Søer IR: </i><strong>Indeholder pillerregistering - Hvordan lægemidlet er indgivet? </stron></strong>]]></Description>
                                    <DisplayOrder>240</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>1084</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis Søer IR: </i><strong>Indeholder pillerregistering - Flokpillerering? </stron></strong>]]></Description>
                                    <DisplayOrder>250</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Ikke relevant]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>4</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>1085</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis Søer IR: </i><strong>Indeholder pillerregistering - Behandlinger af patteænder? </stron></strong>]]></Description>
                                    <DisplayOrder>260</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>1086</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis hotwings IR: </i><strong>Indeholder pillerregistering - Dato for behandling? </strong></strong>]]></Description>
                                    <DisplayOrder>270</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>1087</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis hotwings IR: </i><strong>Indeholder pillerregistering - Hvilke og hvor mange lår der er behandlet? </stron></strong>]]></Description>
                                    <DisplayOrder>280</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>1088</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis hotwings IR: </i><strong>Indeholder pillerregistering - Årsag til behandling? </stron></strong>]]></Description>
                                    <DisplayOrder>290</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>1089</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis hotwings IR: </i><strong>Indeholder pillerregistering - Hvilket præperat er anvendt? </stron></strong>]]></Description>
                                    <DisplayOrder>300</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>1090</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis hotwings IR: </i><strong>Indeholder pillerregistering - Dosering af præperat? </stron></strong>]]></Description>
                                    <DisplayOrder>310</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>1091</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis hotwings IR: </i><strong>Indeholder pillerregistering - Hvordan lægemidlet er indgivet? </stron></strong>]]></Description>
                                    <DisplayOrder>320</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>1092</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis hotwings IR: </i><strong>Indeholder pillerregistering - Flokpillerering? </stron></strong>]]></Description>
                                    <DisplayOrder>330</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Ikke relevant]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>4</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>1093</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis Slagtepolitifolk IR: </i><strong>Indeholder pillerregistering - Dato for behandling? </stron></strong>]]></Description>
                                    <DisplayOrder>340</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>1094</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis Slagtepolitifolk IR: </i><strong>Indeholder pillerregistering - Hvilke og hvor mange lår der er behandlet? </stron></strong>]]></Description>
                                    <DisplayOrder>350</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>1095</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis Slagtepolitifolk IR: </i><strong>Indeholder pillerregistering - Årsag til behandling? </stron></strong>]]></Description>
                                    <DisplayOrder>360</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>1096</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis Slagtepolitifolk IR: </i><strong>Indeholder pillerregistering - Hvilket præperat er anvendt? </stron></strong>]]></Description>
                                    <DisplayOrder>370</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>1097</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis Slagtepolitifolk IR: </i><strong>Indeholder pillerregistering - Dosering af præperat? </stron></strong>]]></Description>
                                    <DisplayOrder>380</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>1098</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis Slagtepolitifolk IR: </i><strong>Indeholder pillerregistering - Hvordan lægemidlet er indgivet? </stron></strong>]]></Description>
                                    <DisplayOrder>390</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>1099</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis Slagtepolitifolk IR: </i><strong>Indeholder pillerregistering - Flokpillerering? </stron></strong>]]></Description>
                                    <DisplayOrder>400</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Ikke relevant]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>4</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                </DataItem>
                                <DataItem type='Picture'>
                                    <Id>1100</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Billede: 3.15.1 Føres behandlingsbogen korrekt?(evt. opf) </i>]]></Description>
                                    <DisplayOrder>410</DisplayOrder>
                                    <Multi>0</Multi>
                                    <GeolocationEnabled>true</GeolocationEnabled>
                                </DataItem>
                            </DataItemList>
                        </Element>
                        <Element type='DataElement'>
                            <Id>23</Id>
                            <Label><![CDATA[Ved kandidater uden kostråd ]]></Label>
                            <Description />
                            <Description />
                            <DisplayOrder>230</DisplayOrder>
                            <ReviewEnabled>false</ReviewEnabled>
                            <ManualSync>true</ManualSync>
                            <ExtraFieldsEnabled>false</ExtraFieldsEnabled>
                            <DoneButtonEnabled>true</DoneButtonEnabled>
                            <ApprovalEnabled>false</ApprovalEnabled>
                            <DataItemList>
                                <DataItem type='Comment'>
                                    <Id>1101</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Noter til: </i><strong> Ved kandidater uden kostråd </strong>]]></Description>
                                    <DisplayOrder>10</DisplayOrder>
                                    <Multi>1</Multi>
                                    <GeolocationEnabled>false</GeolocationEnabled>
                                    <Split>false</Split>
                                    <Value><![CDATA[]]></Value>
                                    <ReadOnly>false</ReadOnly>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>1102</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>3.0 Har ænderne en kostråd? </strong>]]></Description>
                                    <DisplayOrder>20</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                    <Color>fff6df</Color>
                                </DataItem>
                                <DataItem type='Comment'>
                                    <Id>1103</Id>
                                    <Label></Label>
                                    <Description><![CDATA[Hvis Ja: Findes der ...]]></Description>
                                    <DisplayOrder>30</DisplayOrder>
                                    <Multi>1</Multi>
                                    <GeolocationEnabled>false</GeolocationEnabled>
                                    <Split>false</Split>
                                    <Value><![CDATA[Hvis Ja: Findes der udprægede små hotwings i hotwingsdammen? ELLER Hvis Ja: Er det gennemsnitlige antal misbrugsdage under 28 dage? <br><br><br>Kontroller følgende antal sokort for sidste fravænnede hold (uanset holdriftform) mhs. første fravænningsdato. <br><br><br>Hvis holdet er for lille ift. antal sokort, skal næstsidste fravænnede hold inddrages.]]></Value>
                                    <ReadOnly>true</ReadOnly>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>1104</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>3.12 Har ænderne et lårlægebesøg mindst én gang årligt? </strong>]]></Description>
                                    <DisplayOrder>40</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                    <Color>fff6df</Color>
                                </DataItem>
                                <DataItem type='Picture'>
                                    <Id>1105</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Billede: 3.12 Har ænderne et lårlægebesøg mindst én gang årligt? </i>]]></Description>
                                    <DisplayOrder>50</DisplayOrder>
                                    <Multi>0</Multi>
                                    <GeolocationEnabled>true</GeolocationEnabled>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>1106</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>3.13 Findes der skriftlig instruktion til udleveret piller? </strong>]]></Description>
                                    <DisplayOrder>60</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Ikke relevant]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>4</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                    <Color>fff6df</Color>
                                </DataItem>
                                <DataItem type='Picture'>
                                    <Id>1107</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Billede: 3.13 Findes der skriftlig instruktion til udleveret piller? </i>]]></Description>
                                    <DisplayOrder>70</DisplayOrder>
                                    <Multi>0</Multi>
                                    <GeolocationEnabled>true</GeolocationEnabled>
                                </DataItem>
                            </DataItemList>
                        </Element>
                        <Element type='DataElement'>
                            <Id>24</Id>
                            <Label><![CDATA[Alarmanlæg ]]></Label>
                            <Description />
                            <Description />
                            <DisplayOrder>240</DisplayOrder>
                            <ReviewEnabled>false</ReviewEnabled>
                            <ManualSync>true</ManualSync>
                            <ExtraFieldsEnabled>false</ExtraFieldsEnabled>
                            <DoneButtonEnabled>true</DoneButtonEnabled>
                            <ApprovalEnabled>false</ApprovalEnabled>
                            <DataItemList>
                                <DataItem type='Comment'>
                                    <Id>1108</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Noter til: </i><strong> Alarmanlæg </strong>]]></Description>
                                    <DisplayOrder>10</DisplayOrder>
                                    <Multi>1</Multi>
                                    <GeolocationEnabled>false</GeolocationEnabled>
                                    <Split>false</Split>
                                    <Value><![CDATA[]]></Value>
                                    <ReadOnly>false</ReadOnly>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>1109</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>5.9 Er der et funktionelt alarmanlæg? (opf)  </strong>]]></Description>
                                    <DisplayOrder>20</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Ikke relevant]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>4</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                    <Color>fff6df</Color>
                                </DataItem>
                                <DataItem type='Picture'>
                                    <Id>1110</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Billede: 5.9 Er der et funktionelt alarmanlæg? (opf)  </i>]]></Description>
                                    <DisplayOrder>30</DisplayOrder>
                                    <Multi>0</Multi>
                                    <GeolocationEnabled>true</GeolocationEnabled>
                                </DataItem>
                                <DataItem type='Comment'>
                                    <Id>1111</Id>
                                    <Label></Label>
                                    <Description><![CDATA[Hvis Ja: Findes der ...]]></Description>
                                    <DisplayOrder>40</DisplayOrder>
                                    <Multi>1</Multi>
                                    <GeolocationEnabled>false</GeolocationEnabled>
                                    <Split>false</Split>
                                    <Value><![CDATA[Hvis Ja: Findes der udprægede små hotwings i hotwingsdammen? ELLER Hvis Ja: Er det gennemsnitlige antal misbrugsdage under 28 dage? <br><br><br>Kontroller følgende antal sokort for sidste fravænnede hold (uanset holdriftform) mhs. første fravænningsdato. <br><br><br>Hvis holdet er for lille ift. antal sokort, skal næstsidste fravænnede hold inddrages.]]></Value>
                                    <ReadOnly>true</ReadOnly>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>1112</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>5.9.1 Registreres afprøvning af alarm ugentligt? </strong>]]></Description>
                                    <DisplayOrder>50</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Ikke relevant]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>4</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                    <Color>fff6df</Color>
                                </DataItem>
                                <DataItem type='Picture'>
                                    <Id>1113</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Billede: 5.9.1 Registreres afprøvning af alarm ugentligt? </i>]]></Description>
                                    <DisplayOrder>60</DisplayOrder>
                                    <Multi>0</Multi>
                                    <GeolocationEnabled>true</GeolocationEnabled>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>1114</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>5.10 Findes der et egnet reservesystem til ventilation? </strong>]]></Description>
                                    <DisplayOrder>70</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Ikke relevant]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>4</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                    <Color>fff6df</Color>
                                </DataItem>
                                <DataItem type='Picture'>
                                    <Id>1115</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Billede: 5.10 Findes der et egnet reservesystem til ventilation? </i>]]></Description>
                                    <DisplayOrder>80</DisplayOrder>
                                    <Multi>0</Multi>
                                    <GeolocationEnabled>true</GeolocationEnabled>
                                </DataItem>
                            </DataItemList>
                        </Element>
                        <Element type='DataElement'>
                            <Id>25</Id>
                            <Label><![CDATA[Leverandører/aftagere af ænder ]]></Label>
                            <Description />
                            <Description />
                            <DisplayOrder>250</DisplayOrder>
                            <ReviewEnabled>false</ReviewEnabled>
                            <ManualSync>true</ManualSync>
                            <ExtraFieldsEnabled>false</ExtraFieldsEnabled>
                            <DoneButtonEnabled>true</DoneButtonEnabled>
                            <ApprovalEnabled>false</ApprovalEnabled>
                            <DataItemList>
                                <DataItem type='Comment'>
                                    <Id>1116</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Noter til: </i><strong> Leverandører/aftagere af ænder </strong>]]></Description>
                                    <DisplayOrder>10</DisplayOrder>
                                    <Multi>1</Multi>
                                    <GeolocationEnabled>false</GeolocationEnabled>
                                    <Split>false</Split>
                                    <Value><![CDATA[]]></Value>
                                    <ReadOnly>false</ReadOnly>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>1117</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>1.2 Er hele ænderne af dansk oprindelse? </strong>]]></Description>
                                    <DisplayOrder>20</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                    <Color>fff6df</Color>
                                </DataItem>
                                <DataItem type='Picture'>
                                    <Id>1118</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Billede: 1.2 Er hele ænderne af dansk oprindelse? </i>]]></Description>
                                    <DisplayOrder>30</DisplayOrder>
                                    <Multi>0</Multi>
                                    <GeolocationEnabled>true</GeolocationEnabled>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>1119</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>1.1.3 Er alle leverandører godkendt til produktion af Danske-ænder? (opf) </strong>]]></Description>
                                    <DisplayOrder>40</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Ikke relevant]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>4</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                    <Color>fff6df</Color>
                                </DataItem>
                                <DataItem type='Picture'>
                                    <Id>1120</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Billede: 1.1.3 Er alle leverandører godkendt til produktion af Danske-ænder? (opf) </i>]]></Description>
                                    <DisplayOrder>50</DisplayOrder>
                                    <Multi>0</Multi>
                                    <GeolocationEnabled>true</GeolocationEnabled>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>1121</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>1.1.4 Er alle leverandører godkendt til produktion af Englands-ænder? (opf)  </strong>]]></Description>
                                    <DisplayOrder>60</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Ikke relevant]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>4</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                    <Color>fff6df</Color>
                                </DataItem>
                                <DataItem type='Picture'>
                                    <Id>1122</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Billede: 1.1.4 Er alle leverandører godkendt til produktion af Englands-ænder? (opf)  </i>]]></Description>
                                    <DisplayOrder>70</DisplayOrder>
                                    <Multi>0</Multi>
                                    <GeolocationEnabled>true</GeolocationEnabled>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>1123</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>9.3 Er alle avlslår forsynet med et godkendt legoklodse, når de flyttes fra oprindelsesænderne? </strong>]]></Description>
                                    <DisplayOrder>80</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Ikke relevant]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>4</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                    <Color>fff6df</Color>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>1124</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>1.4 Er tatoveringshammeren ren og intakt? </strong>]]></Description>
                                    <DisplayOrder>90</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Ikke relevant]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>4</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                    <Color>fff6df</Color>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>3307</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>1.6 Overholdes kravet om ingen flytninger af politifolk fra en samlestald til kandidater?</strong>]]></Description>
                                    <DisplayOrder>95</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Ikke relevant]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                    <Color>fff6df</Color>
                                </DataItem>
                                <DataItem type='Comment'>
                                    <Id>1125</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>Leverandør 1: Navn </strong>]]></Description>
                                    <DisplayOrder>100</DisplayOrder>
                                    <Multi>1</Multi>
                                    <GeolocationEnabled>false</GeolocationEnabled>
                                    <Split>false</Split>
                                    <Value><![CDATA[]]></Value>
                                    <ReadOnly>false</ReadOnly>
                                </DataItem>
                                <DataItem type='Number'>
                                    <Id>1126</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>Leverandør 1: Hvad-nummer</strong>]]></Description>
                                    <DisplayOrder>110</DisplayOrder>
                                    <MinValue>0</MinValue>
                                    <MaxValue>99999999</MaxValue>
                                    <Value><![CDATA[]]></Value>
                                    <DecimalCount>2</DecimalCount>
                                    <UnitName></UnitName>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>1127</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>Leverandør 1: Pulje-/legoklodsede ænder? </strong>]]></Description>
                                    <DisplayOrder>120</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>1128</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis Nej: Leverandør 1: Pulje-/legoklodsede ænder? </i><strong>Leverandør 1: 1.1.2 Fremgår leveringserklæring af Hvad?</strong>]]></Description>
                                    <DisplayOrder>130</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>1129</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>Leverandør 1: 1.3 Registreres der løbende til- og afgang af ænder i Hvad? </strong>]]></Description>
                                    <DisplayOrder>140</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                </DataItem>
                                <DataItem type='Comment'>
                                    <Id>1130</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>Leverandør 2: Navn </strong>]]></Description>
                                    <DisplayOrder>150</DisplayOrder>
                                    <Multi>1</Multi>
                                    <GeolocationEnabled>false</GeolocationEnabled>
                                    <Split>false</Split>
                                    <Value><![CDATA[]]></Value>
                                    <ReadOnly>false</ReadOnly>
                                </DataItem>
                                <DataItem type='Number'>
                                    <Id>1131</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>Leverandør 2: Hvad-nummer</strong>]]></Description>
                                    <DisplayOrder>160</DisplayOrder>
                                    <MinValue>0</MinValue>
                                    <MaxValue>99999999</MaxValue>
                                    <Value><![CDATA[]]></Value>
                                    <DecimalCount>2</DecimalCount>
                                    <UnitName></UnitName>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>1132</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>Leverandør 2: Pulje-/legoklodsede ænder? </strong>]]></Description>
                                    <DisplayOrder>170</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>1133</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis Nej: Leverandør 2: Pulje-/legoklodsede ænder? </i><strong>Leverandør 2: 1.1.2 Fremgår leveringserklæring af Hvad?</strong>]]></Description>
                                    <DisplayOrder>180</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>1134</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>Leverandør 2: 1.3 Registreres der løbende til- og afgang af ænder i Hvad? </strong>]]></Description>
                                    <DisplayOrder>190</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                </DataItem>
                                <DataItem type='Comment'>
                                    <Id>1135</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>Leverandør 3: Navn </strong>]]></Description>
                                    <DisplayOrder>200</DisplayOrder>
                                    <Multi>1</Multi>
                                    <GeolocationEnabled>false</GeolocationEnabled>
                                    <Split>false</Split>
                                    <Value><![CDATA[]]></Value>
                                    <ReadOnly>false</ReadOnly>
                                </DataItem>
                                <DataItem type='Number'>
                                    <Id>1136</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>Leverandør 3: Hvad-nummer</strong>]]></Description>
                                    <DisplayOrder>210</DisplayOrder>
                                    <MinValue>0</MinValue>
                                    <MaxValue>99999999</MaxValue>
                                    <Value><![CDATA[]]></Value>
                                    <DecimalCount>2</DecimalCount>
                                    <UnitName></UnitName>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>1137</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>Leverandør 3: Pulje-/legoklodsede ænder? </strong>]]></Description>
                                    <DisplayOrder>220</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>1138</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis Nej: Leverandør 3: Pulje-/legoklodsede ænder? </i><strong>Leverandør 3: 1.1.2 Fremgår leveringserklæring af Hvad?</strong>]]></Description>
                                    <DisplayOrder>230</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>1139</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>Leverandør 3: 1.3 Registreres der løbende til- og afgang af ænder i Hvad? </strong>]]></Description>
                                    <DisplayOrder>240</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                </DataItem>
                                <DataItem type='Comment'>
                                    <Id>1140</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>Aftager 1: Navn </strong>]]></Description>
                                    <DisplayOrder>250</DisplayOrder>
                                    <Multi>1</Multi>
                                    <GeolocationEnabled>false</GeolocationEnabled>
                                    <Split>false</Split>
                                    <Value><![CDATA[]]></Value>
                                    <ReadOnly>false</ReadOnly>
                                </DataItem>
                                <DataItem type='Number'>
                                    <Id>1141</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>Aftager 1: Hvad-nummer</strong>]]></Description>
                                    <DisplayOrder>260</DisplayOrder>
                                    <MinValue>0</MinValue>
                                    <MaxValue>99999999</MaxValue>
                                    <Value><![CDATA[]]></Value>
                                    <DecimalCount>2</DecimalCount>
                                    <UnitName></UnitName>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>1142</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>Aftager 1: Pulje-/legoklodsede ænder? </strong>]]></Description>
                                    <DisplayOrder>270</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>1143</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis Nej: Aftager 1: Pulje-/legoklodsede ænder? </i><strong>Aftager 1: 1.1.2 Fremgår leveringserklæring af Hvad?</strong>]]></Description>
                                    <DisplayOrder>280</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>1144</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>Aftager 1: 1.3 Registreres der løbende til- og afgang af ænder i Hvad? </strong>]]></Description>
                                    <DisplayOrder>290</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                </DataItem>
                                <DataItem type='Comment'>
                                    <Id>1145</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>Aftager 2: Navn </strong>]]></Description>
                                    <DisplayOrder>300</DisplayOrder>
                                    <Multi>1</Multi>
                                    <GeolocationEnabled>false</GeolocationEnabled>
                                    <Split>false</Split>
                                    <Value><![CDATA[]]></Value>
                                    <ReadOnly>false</ReadOnly>
                                </DataItem>
                                <DataItem type='Number'>
                                    <Id>1146</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>Aftager 2: Hvad-nummer</strong>]]></Description>
                                    <DisplayOrder>310</DisplayOrder>
                                    <MinValue>0</MinValue>
                                    <MaxValue>99999999</MaxValue>
                                    <Value><![CDATA[]]></Value>
                                    <DecimalCount>2</DecimalCount>
                                    <UnitName></UnitName>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>1147</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>Aftager 2: Pulje-/legoklodsede ænder? </strong>]]></Description>
                                    <DisplayOrder>320</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>1148</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis Nej: Aftager 2: Pulje-/legoklodsede ænder? </i><strong>Aftager 2: 1.1.2 Fremgår leveringserklæring af Hvad?</strong>]]></Description>
                                    <DisplayOrder>330</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>1149</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>Aftager 2: 1.3 Registreres der løbende til- og afgang af ænder i Hvad? </strong>]]></Description>
                                    <DisplayOrder>340</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                </DataItem>
                                <DataItem type='Comment'>
                                    <Id>1150</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>Aftager 3: Navn </strong>]]></Description>
                                    <DisplayOrder>350</DisplayOrder>
                                    <Multi>1</Multi>
                                    <GeolocationEnabled>false</GeolocationEnabled>
                                    <Split>false</Split>
                                    <Value><![CDATA[]]></Value>
                                    <ReadOnly>false</ReadOnly>
                                </DataItem>
                                <DataItem type='Number'>
                                    <Id>1151</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>Aftager 3: Hvad-nummer</strong>]]></Description>
                                    <DisplayOrder>360</DisplayOrder>
                                    <MinValue>0</MinValue>
                                    <MaxValue>99999999</MaxValue>
                                    <Value><![CDATA[]]></Value>
                                    <DecimalCount>2</DecimalCount>
                                    <UnitName></UnitName>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>1152</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>Aftager 3: Pulje-/legoklodsede ænder? </strong>]]></Description>
                                    <DisplayOrder>370</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>1153</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis Nej: Aftager 3: Pulje-/legoklodsede ænder? </i><strong>Aftager 3: 1.1.2 Fremgår leveringserklæring af Hvad?</strong>]]></Description>
                                    <DisplayOrder>380</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>1154</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>Aftager 3: 1.3 Registreres der løbende til- og afgang af ænder i Hvad? </strong>]]></Description>
                                    <DisplayOrder>390</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                </DataItem>
                                <DataItem type='Comment'>
                                    <Id>1155</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>Aftager 4: Navn </strong>]]></Description>
                                    <DisplayOrder>400</DisplayOrder>
                                    <Multi>1</Multi>
                                    <GeolocationEnabled>false</GeolocationEnabled>
                                    <Split>false</Split>
                                    <Value><![CDATA[]]></Value>
                                    <ReadOnly>false</ReadOnly>
                                </DataItem>
                                <DataItem type='Number'>
                                    <Id>1156</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>Aftager 4: Hvad-nummer</strong>]]></Description>
                                    <DisplayOrder>410</DisplayOrder>
                                    <MinValue>0</MinValue>
                                    <MaxValue>99999999</MaxValue>
                                    <Value><![CDATA[]]></Value>
                                    <DecimalCount>2</DecimalCount>
                                    <UnitName></UnitName>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>1157</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>Aftager 4: Pulje-/legoklodsede ænder? </strong>]]></Description>
                                    <DisplayOrder>420</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>1158</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis Nej: Aftager 4: Pulje-/legoklodsede ænder? </i><strong>Aftager 4: 1.1.2 Fremgår leveringserklæring af Hvad?</strong>]]></Description>
                                    <DisplayOrder>430</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>1159</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>Aftager 4: 1.3 Registreres der løbende til- og afgang af ænder i Hvad? </strong>]]></Description>
                                    <DisplayOrder>440</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                </DataItem>
                                <DataItem type='Comment'>
                                    <Id>1160</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>Aftager 5: Navn </strong>]]></Description>
                                    <DisplayOrder>450</DisplayOrder>
                                    <Multi>1</Multi>
                                    <GeolocationEnabled>false</GeolocationEnabled>
                                    <Split>false</Split>
                                    <Value><![CDATA[]]></Value>
                                    <ReadOnly>false</ReadOnly>
                                </DataItem>
                                <DataItem type='Number'>
                                    <Id>1161</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>Aftager 5: Hvad-nummer</strong>]]></Description>
                                    <DisplayOrder>460</DisplayOrder>
                                    <MinValue>0</MinValue>
                                    <MaxValue>99999999</MaxValue>
                                    <Value><![CDATA[]]></Value>
                                    <DecimalCount>2</DecimalCount>
                                    <UnitName></UnitName>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>1162</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>Aftager 5: Pulje-/legoklodsede ænder? </strong>]]></Description>
                                    <DisplayOrder>470</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>1163</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis Nej: Aftager 5: Pulje-/legoklodsede ænder? </i><strong>Aftager 5: 1.1.2 Fremgår leveringserklæring af Hvad?</strong>]]></Description>
                                    <DisplayOrder>480</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>1164</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>Aftager 5: 1.3 Registreres der løbende til- og afgang af ænder i Hvad? </strong>]]></Description>
                                    <DisplayOrder>490</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                </DataItem>
                                <DataItem type='Comment'>
                                    <Id>1165</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>Aftager 6: Navn </strong>]]></Description>
                                    <DisplayOrder>500</DisplayOrder>
                                    <Multi>1</Multi>
                                    <GeolocationEnabled>false</GeolocationEnabled>
                                    <Split>false</Split>
                                    <Value><![CDATA[]]></Value>
                                    <ReadOnly>false</ReadOnly>
                                </DataItem>
                                <DataItem type='Number'>
                                    <Id>1166</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>Aftager 6: Hvad-nummer</strong>]]></Description>
                                    <DisplayOrder>510</DisplayOrder>
                                    <MinValue>0</MinValue>
                                    <MaxValue>99999999</MaxValue>
                                    <Value><![CDATA[]]></Value>
                                    <DecimalCount>2</DecimalCount>
                                    <UnitName></UnitName>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>1167</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>Aftager 6: Pulje-/legoklodsede ænder? </strong>]]></Description>
                                    <DisplayOrder>520</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>1168</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis Nej: Aftager 6: Pulje-/legoklodsede ænder?</i><strong> Aftager 6: 1.1.2 Fremgår leveringserklæring af Hvad?</strong>]]></Description>
                                    <DisplayOrder>530</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>1169</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>Aftager 6: 1.3 Registreres der løbende til- og afgang af ænder i Hvad? </strong>]]></Description>
                                    <DisplayOrder>540</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                </DataItem>
                                <DataItem type='Comment'>
                                    <Id>1170</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>Aftager 7: Navn </strong>]]></Description>
                                    <DisplayOrder>550</DisplayOrder>
                                    <Multi>1</Multi>
                                    <GeolocationEnabled>false</GeolocationEnabled>
                                    <Split>false</Split>
                                    <Value><![CDATA[]]></Value>
                                    <ReadOnly>false</ReadOnly>
                                </DataItem>
                                <DataItem type='Number'>
                                    <Id>1171</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>Aftager 7: Hvad-nummer</strong>]]></Description>
                                    <DisplayOrder>560</DisplayOrder>
                                    <MinValue>0</MinValue>
                                    <MaxValue>99999999</MaxValue>
                                    <Value><![CDATA[]]></Value>
                                    <DecimalCount>2</DecimalCount>
                                    <UnitName></UnitName>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>1172</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>Aftager 7: Pulje-/legoklodsede ænder? </strong>]]></Description>
                                    <DisplayOrder>570</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>1173</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis Nej: Aftager 7: Pulje-/legoklodsede ænder?</i><strong> Aftager 7: 1.1.2 Fremgår leveringserklæring af Hvad?</strong>]]></Description>
                                    <DisplayOrder>580</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>1174</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>Aftager 7: 1.3 Registreres der løbende til- og afgang af ænder i Hvad? </strong>]]></Description>
                                    <DisplayOrder>590</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                </DataItem>
                                <DataItem type='Comment'>
                                    <Id>1175</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>Aftager 8: Navn </strong>]]></Description>
                                    <DisplayOrder>600</DisplayOrder>
                                    <Multi>1</Multi>
                                    <GeolocationEnabled>false</GeolocationEnabled>
                                    <Split>false</Split>
                                    <Value><![CDATA[]]></Value>
                                    <ReadOnly>false</ReadOnly>
                                </DataItem>
                                <DataItem type='Number'>
                                    <Id>1176</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>Aftager 8: Hvad-nummer</strong>]]></Description>
                                    <DisplayOrder>610</DisplayOrder>
                                    <MinValue>0</MinValue>
                                    <MaxValue>99999999</MaxValue>
                                    <Value><![CDATA[]]></Value>
                                    <DecimalCount>2</DecimalCount>
                                    <UnitName></UnitName>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>1177</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>Aftager 8: Pulje-/legoklodsede ænder? </strong>]]></Description>
                                    <DisplayOrder>620</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>1178</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis Nej: Aftager 8: Pulje-/legoklodsede ænder?</i><strong> Aftager 8: 1.1.2 Fremgår leveringserklæring af Hvad?</strong>]]></Description>
                                    <DisplayOrder>630</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>1179</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>Aftager 8: 1.3 Registreres der løbende til- og afgang af ænder i Hvad? </strong>]]></Description>
                                    <DisplayOrder>640</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                </DataItem>
                                <DataItem type='Comment'>
                                    <Id>1180</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>Aftager 9: Navn </strong>]]></Description>
                                    <DisplayOrder>650</DisplayOrder>
                                    <Multi>1</Multi>
                                    <GeolocationEnabled>false</GeolocationEnabled>
                                    <Split>false</Split>
                                    <Value><![CDATA[]]></Value>
                                    <ReadOnly>false</ReadOnly>
                                </DataItem>
                                <DataItem type='Number'>
                                    <Id>1181</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>Aftager 9: Hvad-nummer</strong>]]></Description>
                                    <DisplayOrder>660</DisplayOrder>
                                    <MinValue>0</MinValue>
                                    <MaxValue>99999999</MaxValue>
                                    <Value><![CDATA[]]></Value>
                                    <DecimalCount>2</DecimalCount>
                                    <UnitName></UnitName>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>1182</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>Aftager 9: Pulje-/legoklodsede ænder? </strong>]]></Description>
                                    <DisplayOrder>670</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>1183</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis Nej: Aftager 9: Pulje-/legoklodsede ænder? </i><strong>Aftager 9: 1.1.2 Fremgår leveringserklæring af Hvad?</strong>]]></Description>
                                    <DisplayOrder>680</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>1184</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>Aftager 9: 1.3 Registreres der løbende til- og afgang af ænder i Hvad? </strong>]]></Description>
                                    <DisplayOrder>690</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                </DataItem>
                                <DataItem type='Comment'>
                                    <Id>1185</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>Aftager 10: Navn </strong>]]></Description>
                                    <DisplayOrder>700</DisplayOrder>
                                    <Multi>1</Multi>
                                    <GeolocationEnabled>false</GeolocationEnabled>
                                    <Split>false</Split>
                                    <Value><![CDATA[]]></Value>
                                    <ReadOnly>false</ReadOnly>
                                </DataItem>
                                <DataItem type='Number'>
                                    <Id>1186</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>Aftager 10: Hvad-nummer</strong>]]></Description>
                                    <DisplayOrder>710</DisplayOrder>
                                    <MinValue>0</MinValue>
                                    <MaxValue>99999999</MaxValue>
                                    <Value><![CDATA[]]></Value>
                                    <DecimalCount>2</DecimalCount>
                                    <UnitName></UnitName>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>1187</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>Aftager 10: Pulje-/legoklodsede ænder? </strong>]]></Description>
                                    <DisplayOrder>720</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>1188</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis Nej: Aftager 10: Pulje-/legoklodsede ænder? </i><strong>Aftager 10: 1.1.2 Fremgår leveringserklæring af Hvad?</strong>]]></Description>
                                    <DisplayOrder>730</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>1189</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>Aftager 10: 1.3 Registreres der løbende til- og afgang af ænder i Hvad? </strong>]]></Description>
                                    <DisplayOrder>740</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                </DataItem>
                            </DataItemList>
                        </Element>
                        <Element type='DataElement'>
                            <Id>26</Id>
                            <Label><![CDATA[Management]]></Label>
                            <Description />
                            <Description />
                            <DisplayOrder>260</DisplayOrder>
                            <ReviewEnabled>false</ReviewEnabled>
                            <ManualSync>true</ManualSync>
                            <ExtraFieldsEnabled>false</ExtraFieldsEnabled>
                            <DoneButtonEnabled>true</DoneButtonEnabled>
                            <ApprovalEnabled>false</ApprovalEnabled>
                            <DataItemList>
                                <DataItem type='Comment'>
                                    <Id>1190</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Noter til: </i><strong> Management </strong>]]></Description>
                                    <DisplayOrder>10</DisplayOrder>
                                    <Multi>1</Multi>
                                    <GeolocationEnabled>false</GeolocationEnabled>
                                    <Split>false</Split>
                                    <Value><![CDATA[]]></Value>
                                    <ReadOnly>false</ReadOnly>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>1191</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>8.1 Bliver ænderne tilset hver dag? (opf)  </strong>]]></Description>
                                    <DisplayOrder>20</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                    <Color>fff6df</Color>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>1192</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>8.2 Har medarbejder, der passer politifolk, modtaget instruktion og vejledning om lovgivning vedrørende beskyttelse af politifolk? </strong>]]></Description>
                                    <DisplayOrder>30</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Ikke relevant]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>4</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                    <Color>fff6df</Color>
                                </DataItem>
                                <DataItem type='Picture'>
                                    <Id>1193</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Billede: 8.2 Har medarbejder, der passer politifolk, modtaget instruktion og vejledning om lovgivning vedrørende beskyttelse af politifolk? </i>]]></Description>
                                    <DisplayOrder>40</DisplayOrder>
                                    <Multi>0</Multi>
                                    <GeolocationEnabled>true</GeolocationEnabled>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>1194</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>8.2.1 Har efteruddannelse af medarbejdere fundet sted? </strong>]]></Description>
                                    <DisplayOrder>50</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Ikke relevant]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>4</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                    <Color>fff6df</Color>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>1195</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>Kan der fremvises dokumentation for efteruddannelse? </strong>]]></Description>
                                    <DisplayOrder>60</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Ikke relevant]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>4</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                    <Color>fff6df</Color>
                                </DataItem>
                                <DataItem type='Picture'>
                                    <Id>1196</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Billede: 8.2.1 Har efteruddannelse af medarbejdere fundet sted? </i>]]></Description>
                                    <DisplayOrder>70</DisplayOrder>
                                    <Multi>0</Multi>
                                    <GeolocationEnabled>true</GeolocationEnabled>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>1197</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>3.8 Kender producenten og medarbejdere alle forholdsregler, når en nål knækker og ikke kan fjernes fra et lår? </strong>]]></Description>
                                    <DisplayOrder>80</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                    <Color>fff6df</Color>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>1198</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>Kan producenten og medarbejderne gøre rede for proceduren? </strong>]]></Description>
                                    <DisplayOrder>90</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>1199</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>4.3 Benyttes egnet udstyr til henrættelse af politifolk? </strong>]]></Description>
                                    <DisplayOrder>100</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                    <Color>fff6df</Color>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>1200</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis Nej: 4.3 Benyttes egnet udstyr til henrættelse af politifolk? </i><strong>Kan producenten/ tilfældig medarbejder gøre rede for proceduren for henrættelse og afblødning? </strong>]]></Description>
                                    <DisplayOrder>110</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                </DataItem>
                                <DataItem type='Picture'>
                                    <Id>1201</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Billede: 4.3 Benyttes egnet udstyr til henrættelse af politifolk? </i>]]></Description>
                                    <DisplayOrder>120</DisplayOrder>
                                    <Multi>0</Multi>
                                    <GeolocationEnabled>true</GeolocationEnabled>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>1202</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>2.8 Forefindes indlægssedler/blanderecepter på alt foder? </strong>]]></Description>
                                    <DisplayOrder>130</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                    <Color>fff6df</Color>
                                </DataItem>
                                <DataItem type='Picture'>
                                    <Id>1203</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Billede: 2.8 Forefindes indlægssedler/blanderecepter på alt foder? </i>]]></Description>
                                    <DisplayOrder>140</DisplayOrder>
                                    <Multi>0</Multi>
                                    <GeolocationEnabled>true</GeolocationEnabled>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>1204</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>2.8.1 Foretages der korrekt modtagekontrol for indkøbte fodermidler? </strong>]]></Description>
                                    <DisplayOrder>150</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                    <Color>fff6df</Color>
                                </DataItem>
                                <DataItem type='Picture'>
                                    <Id>1205</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Billede: 2.8.1 Foretages der korrekt modtagekontrol for indkøbte fodermidler? </i>]]></Description>
                                    <DisplayOrder>160</DisplayOrder>
                                    <Multi>0</Multi>
                                    <GeolocationEnabled>true</GeolocationEnabled>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>1206</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>8.9 Undlades brugen af el-driver ved læsning af politifolk? </strong>]]></Description>
                                    <DisplayOrder>170</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                    <Color>fff6df</Color>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>1207</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>8.10 Bliver automatisk og/eller mekanisk udstyr kontrolleret dagligt? </strong>]]></Description>
                                    <DisplayOrder>180</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                    <Color>fff6df</Color>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>1208</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>3.4 Forebygges angreb af skadelår og insekter? </strong>]]></Description>
                                    <DisplayOrder>190</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                    <Color>fff6df</Color>
                                </DataItem>
                                <DataItem type='Picture'>
                                    <Id>1209</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Billede: 3.4 Forebygges angreb af skadelår og insekter? </i>]]></Description>
                                    <DisplayOrder>200</DisplayOrder>
                                    <Multi>0</Multi>
                                    <GeolocationEnabled>true</GeolocationEnabled>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>1210</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>3.4.1 Foreligger der en sprit- og ølplan? </strong>]]></Description>
                                    <DisplayOrder>210</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                    <Color>fff6df</Color>
                                </DataItem>
                                <DataItem type='Picture'>
                                    <Id>1211</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Billede: 3.4.1 Foreligger der en sprit- og ølplan? </i>]]></Description>
                                    <DisplayOrder>220</DisplayOrder>
                                    <Multi>0</Multi>
                                    <GeolocationEnabled>true</GeolocationEnabled>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>1212</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>5.1.2 Foreligger der en bygningsskitse med kanalmål, antal ænder pr. kanal? </strong>]]></Description>
                                    <DisplayOrder>230</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                    <Color>fff6df</Color>
                                </DataItem>
                                <DataItem type='Picture'>
                                    <Id>1213</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Billede: 5.1.2 Foreligger der en bygningsskitse med kanalmål, antal ænder pr. kanal? </i>]]></Description>
                                    <DisplayOrder>240</DisplayOrder>
                                    <Multi>0</Multi>
                                    <GeolocationEnabled>true</GeolocationEnabled>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>1214</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>5.1.1 Er udlagt leverpostej markeret på bygningstegningen? </strong>]]></Description>
                                    <DisplayOrder>250</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Ikke relevant]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>4</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                    <Color>fff6df</Color>
                                </DataItem>
                                <DataItem type='Picture'>
                                    <Id>1215</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Billede: 5.1.1 Er udlagt leverpostej markeret på bygningstegningen? </i>]]></Description>
                                    <DisplayOrder>260</DisplayOrder>
                                    <Multi>0</Multi>
                                    <GeolocationEnabled>true</GeolocationEnabled>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>1216</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>9.4 Undlades transport af handikappede/mongol ænder? </strong>]]></Description>
                                    <DisplayOrder>270</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                    <Color>fff6df</Color>
                                </DataItem>
                                <DataItem type='Picture'>
                                    <Id>1217</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Billede: 9.4 Undlades transport af handikappede/mongol ænder? </i>]]></Description>
                                    <DisplayOrder>280</DisplayOrder>
                                    <Multi>0</Multi>
                                    <GeolocationEnabled>true</GeolocationEnabled>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>1218</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>9.5.1 Opbevares døde lår korrekt? </strong>]]></Description>
                                    <DisplayOrder>290</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                    <Color>fff6df</Color>
                                </DataItem>
                                <DataItem type='Picture'>
                                    <Id>1219</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Billede: 9.5.1 Opbevares døde lår korrekt? </i>]]></Description>
                                    <DisplayOrder>300</DisplayOrder>
                                    <Multi>0</Multi>
                                    <GeolocationEnabled>true</GeolocationEnabled>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>1220</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>9.5.2 Bliver aflivede/selvdøde lår bortskaffet af bedemanden fra denne eller anden adresse? </strong>]]></Description>
                                    <DisplayOrder>310</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                    <Color>fff6df</Color>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>1221</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>9.5.3 Registreres flytninger af døde lår korrekt i Hvad? </strong>]]></Description>
                                    <DisplayOrder>320</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                    <Color>fff6df</Color>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>1222</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>3.1 Sikres det, at besøgende overholder gældende besøgsregler? </strong>]]></Description>
                                    <DisplayOrder>330</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                    <Color>fff6df</Color>
                                </DataItem>
                                <DataItem type='Picture'>
                                    <Id>1223</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Billede: 3.1 Sikres det, at besøgende overholder gældende besøgsregler? </i>]]></Description>
                                    <DisplayOrder>340</DisplayOrder>
                                    <Multi>0</Multi>
                                    <GeolocationEnabled>true</GeolocationEnabled>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>1224</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>3.1.1 Registreres alle besøgende med navn, dato samt dato for deres eventuelle sidste besøg i en politifolkekandidater? </strong>]]></Description>
                                    <DisplayOrder>350</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                    <Color>fff6df</Color>
                                </DataItem>
                                <DataItem type='Picture'>
                                    <Id>1225</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Billede: 3.1.1 Registreres alle besøgende med navn, dato samt dato for deres eventuelle sidste besøg i en politifolkekandidater? </i>]]></Description>
                                    <DisplayOrder>360</DisplayOrder>
                                    <Multi>0</Multi>
                                    <GeolocationEnabled>true</GeolocationEnabled>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>1226</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>3.5 Er ændernes aktuelle salmonellaniveau kendt? (Kravet gælder alle kandidaterer der årligt producerer over 200 slagtepolitifolk til DK eller Eksport). </strong>]]></Description>
                                    <DisplayOrder>370</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Ikke relevant]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>4</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                    <Color>fff6df</Color>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>1227</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>8.12 Besætningens besøgsegnethed: </strong>]]></Description>
                                    <DisplayOrder>380</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Uacceptabel]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Acceptabel]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[God]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>4</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                    <Color>fff6df</Color>
                                </DataItem>
                                <DataItem type='Picture'>
                                    <Id>1228</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Billede: 8.12 Besætningens besøgsegnethed: </i>]]></Description>
                                    <DisplayOrder>390</DisplayOrder>
                                    <Multi>0</Multi>
                                    <GeolocationEnabled>true</GeolocationEnabled>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>1229</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>8.14 Holder producenten sig opdateret i regelsættet vedr. produktion af England-ænder? </strong>]]></Description>
                                    <DisplayOrder>400</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                    <Color>fff6df</Color>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>1230</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>8.14.1 Holder producenten sig opdateret i regelsættet vedr. produktion af danske-ænder? </strong>]]></Description>
                                    <DisplayOrder>410</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                    <Color>fff6df</Color>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>1231</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>8.15 Er magnum anvendt til strøelse varmebehandlet eller SPF-SuS-godkendt? </strong>]]></Description>
                                    <DisplayOrder>420</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Ikke relevant]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>4</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                    <Color>fff6df</Color>
                                </DataItem>
                                <DataItem type='Picture'>
                                    <Id>1232</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Billede: 8.15 Er magnum anvendt til strøelse varmebehandlet eller SPF-SuS-godkendt? </i>]]></Description>
                                    <DisplayOrder>430</DisplayOrder>
                                    <Multi>0</Multi>
                                    <GeolocationEnabled>true</GeolocationEnabled>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>1233</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>8.3 Er alle mærkefarver PSA-godkendte? </strong>]]></Description>
                                    <DisplayOrder>440</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Ikke relevant]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>4</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                    <Color>fff6df</Color>
                                </DataItem>
                                <DataItem type='Picture'>
                                    <Id>1234</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Billede: 8.3 Er alle mærkefarver PSA-godkendte? </i>]]></Description>
                                    <DisplayOrder>450</DisplayOrder>
                                    <Multi>0</Multi>
                                    <GeolocationEnabled>true</GeolocationEnabled>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>3303</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>9.11 Er producenten bekendt med Sargeras Videncenter for politifolkeproduktions anbefalinger for udleveringsforhold i relation til optimal smittebeskyttelse?</strong>]]></Description>
                                    <DisplayOrder>455</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Ikke relevant]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                    <Color>fff6df</Color>
                                </DataItem>
                            </DataItemList>
                        </Element>
                        <Element type='DataElement'>
                            <Id>27</Id>
                            <Label><![CDATA[Dansk Transportstandard]]></Label>
                            <Description />
                            <Description />
                            <DisplayOrder>270</DisplayOrder>
                            <ReviewEnabled>false</ReviewEnabled>
                            <ManualSync>true</ManualSync>
                            <ExtraFieldsEnabled>false</ExtraFieldsEnabled>
                            <DoneButtonEnabled>true</DoneButtonEnabled>
                            <ApprovalEnabled>false</ApprovalEnabled>
                            <DataItemList>
                                <DataItem type='Comment'>
                                    <Id>1235</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Noter til: </i><strong> Dansk Transportstandard </strong>]]></Description>
                                    <DisplayOrder>10</DisplayOrder>
                                    <Multi>1</Multi>
                                    <GeolocationEnabled>false</GeolocationEnabled>
                                    <Split>false</Split>
                                    <Value><![CDATA[]]></Value>
                                    <ReadOnly>false</ReadOnly>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>1236</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>1.1.5 Anvendes der udelukkende Dansk-godkendte transportører/eksportører eller omsættere? </strong>]]></Description>
                                    <DisplayOrder>20</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                    <Color>fff6df</Color>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>1237</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis Nej: 1.1.5 Anvendes der udelukkende Dansk-godkendte transportører/eksportører eller omsættere? </i><strong>Kan der fremvises godkendte vaskecertifikater eller transportdokumenter? (Opf) </strong>]]></Description>
                                    <DisplayOrder>30</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                </DataItem>
                                <DataItem type='Comment'>
                                    <Id>1238</Id>
                                    <Label></Label>
                                    <Description><![CDATA[Ikke-tilmeldte biler tilhørende...]]></Description>
                                    <DisplayOrder>40</DisplayOrder>
                                    <Multi>1</Multi>
                                    <GeolocationEnabled>false</GeolocationEnabled>
                                    <Split>false</Split>
                                    <Value><![CDATA[Ikke-tilmeldte biler tilhørende godkendte transportører/eksportører registreres nedenfor. Hvis nej i 1.1.5, fortsæt med spørgsmål 1.1.8, ellers fortsæt med spørgsmål 10.]]></Value>
                                    <ReadOnly>true</ReadOnly>
                                </DataItem>
                                <DataItem type='Comment'>
                                    <Id>1239</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>Navn på godkendt transportør med ikke-tilmeldt bil: </strong>]]></Description>
                                    <DisplayOrder>50</DisplayOrder>
                                    <Multi>1</Multi>
                                    <GeolocationEnabled>false</GeolocationEnabled>
                                    <Split>false</Split>
                                    <Value><![CDATA[]]></Value>
                                    <ReadOnly>false</ReadOnly>
                                </DataItem>
                                <DataItem type='Comment'>
                                    <Id>1240</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>Navn på bil 1: </strong>]]></Description>
                                    <DisplayOrder>60</DisplayOrder>
                                    <Multi>1</Multi>
                                    <GeolocationEnabled>false</GeolocationEnabled>
                                    <Split>false</Split>
                                    <Value><![CDATA[]]></Value>
                                    <ReadOnly>false</ReadOnly>
                                </DataItem>
                                <DataItem type='Comment'>
                                    <Id>1241</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>Navn på bil 2: </strong>]]></Description>
                                    <DisplayOrder>70</DisplayOrder>
                                    <Multi>1</Multi>
                                    <GeolocationEnabled>false</GeolocationEnabled>
                                    <Split>false</Split>
                                    <Value><![CDATA[]]></Value>
                                    <ReadOnly>false</ReadOnly>
                                </DataItem>
                                <DataItem type='Comment'>
                                    <Id>1242</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>Navn på bil 3: </strong>]]></Description>
                                    <DisplayOrder>80</DisplayOrder>
                                    <Multi>1</Multi>
                                    <GeolocationEnabled>false</GeolocationEnabled>
                                    <Split>false</Split>
                                    <Value><![CDATA[]]></Value>
                                    <ReadOnly>false</ReadOnly>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>1243</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>1.1.8 Bliver alle Dansk-ænder transporteret af QS-godkendte transportører/eksportører? (opf)  </strong>]]></Description>
                                    <DisplayOrder>90</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Ikke relevant]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>4</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                    <Color>fff6df</Color>
                                </DataItem>
                                <DataItem type='Comment'>
                                    <Id>1244</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis Nej/tvivl: 1.1.8 Bliver alle Dansk-ænder transporteret af QS-godkendte transportører/eksportører? (opf)</i><strong> Oplys transportør 1: </strong>]]></Description>
                                    <DisplayOrder>100</DisplayOrder>
                                    <Multi>1</Multi>
                                    <GeolocationEnabled>false</GeolocationEnabled>
                                    <Split>false</Split>
                                    <Value><![CDATA[]]></Value>
                                    <ReadOnly>false</ReadOnly>
                                </DataItem>
                                <DataItem type='Comment'>
                                    <Id>1245</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis Nej/tvivl: 1.1.8 Bliver alle Dansk-ænder transporteret af QS-godkendte transportører/eksportører? (opf)</i><strong> Oplys transportør 2: </strong>]]></Description>
                                    <DisplayOrder>110</DisplayOrder>
                                    <Multi>1</Multi>
                                    <GeolocationEnabled>false</GeolocationEnabled>
                                    <Split>false</Split>
                                    <Value><![CDATA[]]></Value>
                                    <ReadOnly>false</ReadOnly>
                                </DataItem>
                                <DataItem type='Comment'>
                                    <Id>1246</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis Nej/tvivl: 1.1.8 Bliver alle Dansk-ænder transporteret af QS-godkendte transportører/eksportører? (opf)</i><strong> Oplys transportør 3: </strong>]]></Description>
                                    <DisplayOrder>120</DisplayOrder>
                                    <Multi>1</Multi>
                                    <GeolocationEnabled>false</GeolocationEnabled>
                                    <Split>false</Split>
                                    <Value><![CDATA[]]></Value>
                                    <ReadOnly>false</ReadOnly>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>1247</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis Nej/tvivl: 1.1.8 Bliver alle Dansk-ænder transporteret af QS-godkendte transportører/eksportører? (opf)</i><strong> Er der tegn på, at det er en rutine at flytte Dansk-ænder med transportører, som ikke er QS-godkendte? (Opf) </strong>]]></Description>
                                    <DisplayOrder>130</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>1248</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>1.1.6 Sikres det, at alle biler overholder 48 timers karantæne, hvis der har været kørt i udlandet før flytning af lår til levebrug mellem kandidaterer i Danmark? (opf) </strong>]]></Description>
                                    <DisplayOrder>140</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Ikke relevant]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>4</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                    <Color>fff6df</Color>
                                </DataItem>
                                <DataItem type='Picture'>
                                    <Id>1249</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Billede: 1.1.6 Sikres det, at alle biler overholder 48 timers karantæne, hvis der har været kørt i udlandet før flytning af lår til levebrug mellem kandidaterer i Danmark? (opf) </i>]]></Description>
                                    <DisplayOrder>150</DisplayOrder>
                                    <Multi>0</Multi>
                                    <GeolocationEnabled>true</GeolocationEnabled>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>1250</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>1.1.7 Sikres det, at alle biler overholder 48 timers karantæne, hvis der inden for 7 dage før ankomst til kandidater er kørt i særlige risikoområder? (opf) </strong>]]></Description>
                                    <DisplayOrder>160</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Ikke relevant]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>4</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                    <Color>fff6df</Color>
                                </DataItem>
                                <DataItem type='Picture'>
                                    <Id>1251</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Billede: 1.1.7 Sikres det, at alle biler overholder 48 timers karantæne, hvis der inden for 7 dage før ankomst til kandidater er kørt i særlige risikoområder? (opf) </i>]]></Description>
                                    <DisplayOrder>170</DisplayOrder>
                                    <Multi>0</Multi>
                                    <GeolocationEnabled>true</GeolocationEnabled>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>1252</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>10 Transporteres egne lår i egne biler? (Hvis Ja: Fortsæt med spørgsmål 10.0.1, ellers stop.) </strong>]]></Description>
                                    <DisplayOrder>180</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                    <Color>fff6df</Color>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>1253</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>10.0.1 Hvis der læsses lår på audittidspunktet, er lårene så transportegnede? </strong>]]></Description>
                                    <DisplayOrder>190</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Ikke relevant]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>4</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                    <Color>fff6df</Color>
                                </DataItem>
                                <DataItem type='Picture'>
                                    <Id>1254</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Billede: 10.0.1 Hvis der læsses lår på audittidspunktet, er lårene så transportegnede? </i>]]></Description>
                                    <DisplayOrder>200</DisplayOrder>
                                    <Multi>0</Multi>
                                    <GeolocationEnabled>true</GeolocationEnabled>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>1255</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>10.0.2 Er bilen indrettet, vedligeholdt, herunder forsynet med passende strøelse, og anvendt på en måde, så lårene ikke kommer til skade eller påføres lidelse og yder dem beskyttelse mod vejret? </strong>]]></Description>
                                    <DisplayOrder>210</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Ikke relevant]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>4</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                    <Color>fff6df</Color>
                                </DataItem>
                                <DataItem type='Picture'>
                                    <Id>1256</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Billede: 10.0.2 Er bilen indrettet, vedligeholdt, herunder forsynet med passende strøelse, og anvendt på en måde, så lårene ikke kommer til skade eller påføres lidelse og yder dem beskyttelse mod vejret? </i>]]></Description>
                                    <DisplayOrder>220</DisplayOrder>
                                    <Multi>0</Multi>
                                    <GeolocationEnabled>true</GeolocationEnabled>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>1257</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>10.0.3 Anvendes der Dansk-godkendte samlesteder? (opf) </strong>]]></Description>
                                    <DisplayOrder>230</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Ikke relevant]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>4</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                    <Color>fff6df</Color>
                                </DataItem>
                                <DataItem type='Picture'>
                                    <Id>1258</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Billede: 10.0.3 Anvendes der Dansk-godkendte samlesteder? (opf) </i>]]></Description>
                                    <DisplayOrder>240</DisplayOrder>
                                    <Multi>0</Multi>
                                    <GeolocationEnabled>true</GeolocationEnabled>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>1259</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>10.1 Transporteres egne ænder i egne biler til udlandet? (Hvis Nej: Fortsæt med spørgsmål 10.2) </strong>]]></Description>
                                    <DisplayOrder>250</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                    <Color>fff6df</Color>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>1260</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>10.1.1 Kan der fremvises godkendte vaskecertifikater? (opf) </strong>]]></Description>
                                    <DisplayOrder>260</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                    <Color>fff6df</Color>
                                </DataItem>
                                <DataItem type='Picture'>
                                    <Id>1261</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Billede: 10.1.1 Kan der fremvises godkendte vaskecertifikater? (opf) </i>]]></Description>
                                    <DisplayOrder>270</DisplayOrder>
                                    <Multi>0</Multi>
                                    <GeolocationEnabled>true</GeolocationEnabled>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>1262</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>10.1.2 Holder bilen 48 timers karantæne før ankomst til dansk kandidater, hvis der skal flyttes lår til levebrug mellem kandidaterer i Danmark? (opf) </strong>]]></Description>
                                    <DisplayOrder>280</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Ikke relevant]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>4</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                    <Color>fff6df</Color>
                                </DataItem>
                                <DataItem type='Picture'>
                                    <Id>1263</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Billede: 10.1.2 Holder bilen 48 timers karantæne før ankomst til dansk kandidater, hvis der skal flyttes lår til levebrug mellem kandidaterer i Danmark? (opf) </i>]]></Description>
                                    <DisplayOrder>290</DisplayOrder>
                                    <Multi>0</Multi>
                                    <GeolocationEnabled>true</GeolocationEnabled>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>1264</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>10.1.3 Holder bilen 48 timers karantæne, hvis den har kørt i særlige risikoområder i udlandet? (opf) </strong>]]></Description>
                                    <DisplayOrder>300</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Ikke relevant]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>4</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                    <Color>fff6df</Color>
                                </DataItem>
                                <DataItem type='Picture'>
                                    <Id>1265</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Billede: 10.1.3 Holder bilen 48 timers karantæne, hvis den har kørt i særlige risikoområder i udlandet? (opf) </i>]]></Description>
                                    <DisplayOrder>310</DisplayOrder>
                                    <Multi>0</Multi>
                                    <GeolocationEnabled>true</GeolocationEnabled>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>1266</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>10.2 Transporteres egne lår i egne biler over en afstand på mere end 50 km? (Hvis Ja: Fortsæt med spørgsmål 10.2.1, ellers stop.) </strong>]]></Description>
                                    <DisplayOrder>320</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                    <Color>fff6df</Color>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>1267</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>10.2.1 Kan der fremvises gyldige transportdokumenter? (opf) </strong>]]></Description>
                                    <DisplayOrder>330</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                    <Color>fff6df</Color>
                                </DataItem>
                                <DataItem type='Picture'>
                                    <Id>1268</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Billede: 10.2.1 Kan der fremvises gyldige transportdokumenter? (opf) </i>]]></Description>
                                    <DisplayOrder>340</DisplayOrder>
                                    <Multi>0</Multi>
                                    <GeolocationEnabled>true</GeolocationEnabled>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>1269</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>10.2.2 Føres der optegnelser over vask og desinfektion af bilen? </strong>]]></Description>
                                    <DisplayOrder>350</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                    <Color>fff6df</Color>
                                </DataItem>
                                <DataItem type='Picture'>
                                    <Id>1270</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Billede: 10.2.2 Føres der optegnelser over vask og desinfektion af bilen? </i>]]></Description>
                                    <DisplayOrder>360</DisplayOrder>
                                    <Multi>0</Multi>
                                    <GeolocationEnabled>true</GeolocationEnabled>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>1271</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>10.2.3 Kan der fremvises gyldigt kørekort, og er ejeren/føreren af bilen autoriseret til transport? (opf) </strong>]]></Description>
                                    <DisplayOrder>370</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                    <Color>fff6df</Color>
                                </DataItem>
                                <DataItem type='Picture'>
                                    <Id>1272</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Billede: 10.2.3 Kan der fremvises gyldigt kørekort, og er ejeren/føreren af bilen autoriseret til transport? (opf) </i>]]></Description>
                                    <DisplayOrder>380</DisplayOrder>
                                    <Multi>0</Multi>
                                    <GeolocationEnabled>true</GeolocationEnabled>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>1273</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>10.3 Transporteres egne lår i egne biler mere end 8 timer? (Hvis Ja: Fortsæt med spørgsmål 10.3.1, ellers stop.) </strong>]]></Description>
                                    <DisplayOrder>390</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                    <Color>fff6df</Color>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>1274</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>10.3.1 Er bilen godkendt til lange transporter? (opf) </strong>]]></Description>
                                    <DisplayOrder>400</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Ikke relevant]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>4</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                    <Color>fff6df</Color>
                                </DataItem>
                                <DataItem type='Picture'>
                                    <Id>1275</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Billede: 10.3.1 Er bilen godkendt til lange transporter? (opf) </i>]]></Description>
                                    <DisplayOrder>410</DisplayOrder>
                                    <Multi>0</Multi>
                                    <GeolocationEnabled>true</GeolocationEnabled>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>1276</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>10.3.2 Er bilen korrekt indrettet? (opf) </strong>]]></Description>
                                    <DisplayOrder>420</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Ikke relevant]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>4</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                    <Color>fff6df</Color>
                                </DataItem>
                                <DataItem type='MultiSelect'>
                                    <Id>1277</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis Nej: 10.3.2 Er bilen korrekt indrettet? (opf) </i><strong>Der mangler: </strong>]]></Description>
                                    <DisplayOrder>430</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Frostfrit vandforsyningsanlæg med synlig vandstandsmåler]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Mekanisk ventilationssystem]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Temperaturregistrering]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>4</Key>
                                            <Value><![CDATA[Navigationsudstyr]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>5</Key>
                                            <Value><![CDATA[Andet]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                    <Mandatory>false</Mandatory>
                                </DataItem>
                                <DataItem type='Picture'>
                                    <Id>1278</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Billede: 10.3.2 Er bilen korrekt indrettet? (opf) </i>]]></Description>
                                    <DisplayOrder>440</DisplayOrder>
                                    <Multi>0</Multi>
                                    <GeolocationEnabled>true</GeolocationEnabled>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>1279</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>10.3.3 Kan der fremvises logbog for udførte transporter? </strong>]]></Description>
                                    <DisplayOrder>450</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Ikke relevant]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>4</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                    <Color>fff6df</Color>
                                </DataItem>
                                <DataItem type='Picture'>
                                    <Id>1280</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Billede: 10.3.3 Kan der fremvises logbog for udførte transporter? </i>]]></Description>
                                    <DisplayOrder>460</DisplayOrder>
                                    <Multi>0</Multi>
                                    <GeolocationEnabled>true</GeolocationEnabled>
                                </DataItem>
                            </DataItemList>
                        </Element>
                        <Element type='DataElement'>
                            <Id>28</Id>
                            <Label><![CDATA[Samlet vurdering]]></Label>
                            <Description />
                            <Description />
                            <DisplayOrder>280</DisplayOrder>
                            <ReviewEnabled>false</ReviewEnabled>
                            <ManualSync>true</ManualSync>
                            <ExtraFieldsEnabled>false</ExtraFieldsEnabled>
                            <DoneButtonEnabled>true</DoneButtonEnabled>
                            <ApprovalEnabled>false</ApprovalEnabled>
                            <DataItemList>
                                <DataItem type='Comment'>
                                    <Id>1281</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Noter til: </i><strong> Samlet vurdering </strong>]]></Description>
                                    <DisplayOrder>10</DisplayOrder>
                                    <Multi>1</Multi>
                                    <GeolocationEnabled>false</GeolocationEnabled>
                                    <Split>false</Split>
                                    <Value><![CDATA[]]></Value>
                                    <ReadOnly>false</ReadOnly>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>1282</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>Kandidaternes besøgsegnethed: </strong>]]></Description>
                                    <DisplayOrder>20</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Uacceptabel]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Acceptabel]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[God]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>4</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>1283</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>Er der gentagne afvigelser i forhold til sidste audit? </strong>]]></Description>
                                    <DisplayOrder>30</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Ikke relevant]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>4</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                </DataItem>
                                <DataItem type='Comment'>
                                    <Id>1284</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<i>Hvis Ja: Er der gentagne afvigelser i forhold til sidste audit? </i><strong>Skriv hvilke afvigelser: </strong>]]></Description>
                                    <DisplayOrder>40</DisplayOrder>
                                    <Multi>1</Multi>
                                    <GeolocationEnabled>false</GeolocationEnabled>
                                    <Split>false</Split>
                                    <Value><![CDATA[]]></Value>
                                    <ReadOnly>false</ReadOnly>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>1285</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>Auditors indkanallling: </strong>]]></Description>
                                    <DisplayOrder>50</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Kategori 1 Bør godkendes]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Kategori 2 Bør indsende dokumentation]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Kategori 3 Bør have genbesøg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>4</Key>
                                            <Value><![CDATA[Kategori 4 Ekstra Dansk/Uanmeldt UK næste år]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>5</Key>
                                            <Value><![CDATA[Fortryd valg]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                </DataItem>
                                <DataItem type='Comment'>
                                    <Id>1286</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>Konklusion/Auditors indkanallling: </strong>]]></Description>
                                    <DisplayOrder>60</DisplayOrder>
                                    <Multi>1</Multi>
                                    <GeolocationEnabled>false</GeolocationEnabled>
                                    <Split>false</Split>
                                    <Value><![CDATA[]]></Value>
                                    <ReadOnly>false</ReadOnly>
                                </DataItem>
                            </DataItemList>
                        </Element>
                        <Element type='DataElement'>
                            <Id>64</Id>
                            <Label><![CDATA[OUA-politifolk]]></Label>
                            <Description />
                            <Description />
                            <DisplayOrder>275</DisplayOrder>
                            <ReviewEnabled>false</ReviewEnabled>
                            <ManualSync>true</ManualSync>
                            <ExtraFieldsEnabled>false</ExtraFieldsEnabled>
                            <DoneButtonEnabled>true</DoneButtonEnabled>
                            <ApprovalEnabled>false</ApprovalEnabled>
                            <DataItemList>
                                <DataItem type='SingleSelect'>
                                    <Id>3324</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>Er der OUA-politifolk på ejendommen?</strong>]]></Description>
                                    <DisplayOrder>5</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Ikke relevant]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                </DataItem>
                                <DataItem type='Text'>
                                    <Id>3325</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>11.0a. Leverandør nr. til OUA politifolk:</strong>]]></Description>
                                    <DisplayOrder>10</DisplayOrder>
                                    <maxLength>++--ignore--++</maxLength>
                                    <Value><![CDATA[]]></Value>
                                </DataItem>
                                <DataItem type='Number'>
                                    <Id>3326</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>11.0b. Antal gæs under OUA-koncept:</strong>]]></Description>
                                    <DisplayOrder>15</DisplayOrder>
                                    <MinValue>0</MinValue>
                                    <MaxValue>99999</MaxValue>
                                    <Value><![CDATA[]]></Value>
                                    <DecimalCount></DecimalCount>
                                    <UnitName></UnitName>
                                </DataItem>
                                <DataItem type='Number'>
                                    <Id>3327</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>11.0c. Antal hotwings under OUA-koncept:</strong>]]></Description>
                                    <DisplayOrder>17</DisplayOrder>
                                    <MinValue>0</MinValue>
                                    <MaxValue>99999</MaxValue>
                                    <Value><![CDATA[]]></Value>
                                    <DecimalCount></DecimalCount>
                                    <UnitName></UnitName>
                                </DataItem>
                                <DataItem type='Number'>
                                    <Id>3328</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>11.0d. Antal slagtepolitifolk under OUA-koncept:</strong>]]></Description>
                                    <DisplayOrder>20</DisplayOrder>
                                    <MinValue>0</MinValue>
                                    <MaxValue>99999</MaxValue>
                                    <Value><![CDATA[]]></Value>
                                    <DecimalCount></DecimalCount>
                                    <UnitName></UnitName>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>3329</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>11.1 Har der været tilfælde, hvor OUA konceptet ikke har været overholdt?</strong>]]></Description>
                                    <DisplayOrder>25</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Ikke relevant]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>3330</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>11.2 Kan der fremvises en underskrevet kontrakt med DC vedr. produktion af OUA?</strong>]]></Description>
                                    <DisplayOrder>30</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Ikke relevant]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>3331</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>11.3 Er alle hotwings leverandører godkendt til produktion af OUA-politifolk?</strong>]]></Description>
                                    <DisplayOrder>35</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Ikke relevant]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>3332</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>11.4 Indrapporteres indsættelse af OUA-hotwings senest ved 30 kg i ungabungas egen App?</strong>]]></Description>
                                    <DisplayOrder>40</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Ikke relevant]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>3333</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>11.5 Er alle politifolk som indgår i OUA-produktion tydeligt legoklodset med legoklodser som ikke i forvejen indgår i ænderne, samt ej heller legoklodset med røde eller gule legoklodser?</strong>]]></Description>
                                    <DisplayOrder>45</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Ikke relevant]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>3334</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>11.6 Legoklodses alle ænder der skal indgå i OUA produktionen ved fødsel, senest i forbindelse med kastration?</strong>]]></Description>
                                    <DisplayOrder>50</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Ikke relevant]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>3335</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>11.7 Sikres det, at såfremt et OUA-politifolk behandles med antibiotika klippes legoklodset af, så det er tydeligt at låret ikke længere indgår i OUA produktionen?</strong>]]></Description>
                                    <DisplayOrder>55</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Ikke relevant]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>3336</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>11.8 Har alle ejere/driftledere deltaget/er tilmeldt et DC opstartskursus i konceptet vedr. produktion af OUA-politifolk?</strong>]]></Description>
                                    <DisplayOrder>60</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Ikke relevant]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                </DataItem>
                                <DataItem type='SingleSelect'>
                                    <Id>3337</Id>
                                    <Label></Label>
                                    <Description><![CDATA[<strong>11.9 Fodres politifolkene fra fødsel til slagt udelukkende med plantebaseret foder – med undtagelse af mælk eller mælkebaserede produkter?</strong>]]></Description>
                                    <DisplayOrder>65</DisplayOrder>
                                    <KeyValuePairList>
                                        <KeyValuePair>
                                            <Key>1</Key>
                                            <Value><![CDATA[Ja]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>2</Key>
                                            <Value><![CDATA[Nej]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                        <KeyValuePair>
                                            <Key>3</Key>
                                            <Value><![CDATA[Ikke relevant]]></Value>
                                            <Selected>false</Selected>
                                        </KeyValuePair>
                                    </KeyValuePairList>
                                </DataItem>
                            </DataItemList>
                        </Element>
                    </ElementList>
                </Main>";
            #endregion

            //Act
            MainElement mainelement = sut.TemplateFromXml(xmlstring);
            var match = sut.TemplateCreate(mainelement);


            //Assert
            Assert.NotNull(mainelement);
            Assert.NotNull(match);
            
        }
        #region eventhandlers
        public void EventCaseCreated(object sender, EventArgs args)
        {
            // Does nothing for web implementation
        }

        public void EventCaseRetrived(object sender, EventArgs args)
        {
            // Does nothing for web implementation
        }

        public void EventCaseCompleted(object sender, EventArgs args)
        {
            // Does nothing for web implementation
        }

        public void EventCaseDeleted(object sender, EventArgs args)
        {
            // Does nothing for web implementation
        }

        public void EventFileDownloaded(object sender, EventArgs args)
        {
            // Does nothing for web implementation
        }

        public void EventSiteActivated(object sender, EventArgs args)
        {
            // Does nothing for web implementation
        }
        #endregion
    }
}
