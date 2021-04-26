﻿using System;
using System.Collections.Generic;
using System.IO;

namespace SharpIpp.Model
{
    public class PrintJobRequest
    {
        public IppVersion IppVersion { get; set; } = IppVersion.V11;
        public int RequestId { get; set; } = 1;
        public Uri PrinterUri { get; set; } = null!;
        public Stream Document { get; set; } = null!;

        /// <summary>
        ///     The client OPTIONALLY supplies this attribute.  The Printer
        ///     object MUST support this attribute.  It contains the client
        ///     supplied Job name.  If this attribute is supplied by the
        ///     client, its value is used for the "job-name" attribute of the
        ///     newly created Job object.  The client MAY automatically include
        ///     any information that will help the end-user distinguish amongst
        ///     his/her jobs, such as the name of the application program along
        ///     with information from the document, such as the document name,
        ///     document subject, or source file name.  If this attribute is
        ///     not supplied by the client, the Printer generates a name to use
        ///     in the "job-name" attribute of the newly created Job object
        /// </summary>
        public string? JobName { get; set; }

        /// <summary>
        ///     The client OPTIONALLY supplies this attribute.  The Printer
        ///     object MUST support this attribute.  The value 'true' indicates
        ///     that total fidelity to client supplied Job Template attributes
        ///     and values is required, else the Printer object MUST reject the
        ///     Print-Job request.  The value 'false' indicates that a
        ///     reasonable attempt to print the Job object is acceptable and
        ///     the Printer object MUST accept the Print-Job request. If not
        ///     supplied, the Printer object assumes the value is 'false'.  All
        ///     Printer objects MUST support both types of job processing.  See
        ///     section 15 for a full description of "ipp-attribute-fidelity"
        ///     and its relationship to other attributes, especially the
        ///     Printer object's "pdl-override-supported" attribute.
        /// </summary>
        public bool? IppAttributeFidelity { get; set; }

        /// <summary>
        ///     The client OPTIONALLY supplies this attribute.  The Printer
        ///     object MUST support this attribute.  The value 'true' indicates
        ///     that total fidelity to client supplied Job Template attributes
        ///     and values is required, else the Printer object MUST reject the
        ///     Print-Job request.  The value 'false' indicates that a
        ///     reasonable attempt to print the Job object is acceptable and
        ///     the Printer object MUST accept the Print-Job request. If not
        ///     supplied, the Printer object assumes the value is 'false'.  All
        ///     Printer objects MUST support both types of job processing.  See
        ///     section 15 for a full description of "ipp-attribute-fidelity"
        ///     and its relationship to other attributes, especially the
        ///     Printer object's "pdl-override-supported" attribute.
        /// </summary>
        public string? DocumentName { get; set; }

        /// <summary>
        ///     The client OPTIONALLY supplies this attribute.  The Printer
        ///     object MUST support this attribute.  The value of this
        ///     attribute identifies the format of the supplied document data.
        /// </summary>
        /// <example>application/octet-stream</example>
        public string? DocumentFormat { get; set; }

        /// <summary>
        ///     The client OPTIONALLY supplies this attribute.  The Printer
        ///     object OPTIONALLY supports this attribute. This attribute
        ///     specifies the natural language of the document for those
        ///     document-formats that require a specification of the natural
        ///     language in order to image the document unambiguously. There
        ///     are no particular values required for the Printer object to
        ///     support.
        /// </summary>
        public string? DocumentNaturalLanguage { get; set; }

        /// <summary>
        ///     This attribute specifies a priority for scheduling the Job. A higher
        ///     value specifies a higher priority. The value 1 indicates the lowest
        ///     possible priority. The value 100 indicates the highest possible
        ///     priority.  Among those jobs that are ready to print, a Printer MUST
        ///     print all jobs with a priority value of n before printing those with
        ///     a priority value of n-1 for all n.
        ///     If the Printer object supports this attribute, it MUST always support
        ///     the full range from 1 to 100.  No administrative restrictions are
        ///     permitted.  This way an end-user can always make full use of the
        ///     entire range with any Printer object.  If privileged jobs are
        ///     implemented outside IPP/1.1, they MUST have priorities higher than
        ///     100, rather than restricting the range available to end-users.
        ///     If the client does not supply this attribute and this attribute is
        ///     supported by the Printer object, the Printer object MUST use the
        ///     value of the Printer object's "job-priority-default" at job
        ///     submission time (unlike most Job Template attributes that are used if
        ///     necessary at job processing time).
        /// </summary>
        public int? JobPriority { get; set; }

        /// <summary>
        ///     This attribute specifies the named time period during which the Job
        ///     MUST become a candidate for printing.
        /// </summary>
        public JobHoldUntil? JobHoldUntil { get; set; }

        public MultipleDocumentHandling? MultipleDocumentHandling { get; set; }

        /// <summary>
        ///     This attribute specifies the number of copies to be printed.
        ///     On many devices the supported number of collated copies will be
        ///     limited by the number of physical output bins on the device, and may
        ///     be different from the number of uncollated copies which can be
        ///     supported.
        /// </summary>
        public int? Copies { get; set; }

        /// <summary>
        ///     This attribute identifies the finishing operations that the Printer
        ///     uses for each copy of each printed document in the Job. For Jobs with
        ///     multiple documents, the "multiple-document-handling" attribute
        ///     determines what constitutes a "copy" for purposes of finishing.
        /// </summary>
        public Finishings? Finishings { get; set; }

        /// <summary>
        ///     This attribute identifies the range(s) of print-stream pages that the
        ///     Printer object uses for each copy of each document which are to be
        ///     printed.  Nothing is printed for any pages identified that do not
        ///     exist in the document(s).  Ranges MUST be in ascending order, for
        ///     example: 1-3, 5-7, 15-19 and MUST NOT overlap, so that a non-spooling
        ///     Printer object can process the job in a single pass.  If the ranges
        ///     are not ascending or are overlapping, the IPP object MUST reject the
        ///     request and return the 'client-error-bad-request' status code.  The
        ///     attribute is associated with print-stream pages not application-
        ///     numbered pages (for example, the page numbers found in the headers
        ///     and or footers for certain word processing applications).
        ///     For Jobs with multiple documents, the "multiple-document-handling"
        ///     attribute determines what constitutes a "copy" for purposes of the
        ///     specified page range(s).  When "multiple-document-handling" is
        ///     'single-document', the Printer object MUST apply each supplied page
        ///     range once to the concatenation of the print-stream pages.  For
        ///     example, if there are 8 documents of 10 pages each, the page-range
        ///     '41:60' prints the pages in the 5th and 6th documents as a single
        ///     document and none of the pages of the other documents are printed.
        ///     When "multiple-document- handling" is 'separate-documents-
        ///     uncollated-copies' or 'separate-documents-collated-copies', the
        ///     Printer object MUST apply each supplied page range repeatedly to each
        ///     document copy.  For the same job, the page-range '1:3, 10:10' would
        ///     print the first 3 pages and the 10th page of each of the 8 documents
        ///     in the Job, as 8 separate documents.
        ///     In most cases, the exact pages to be printed will be generated by a
        ///     device driver and this attribute would not be required.  However,
        ///     when printing an archived document which has already been formatted,
        ///     the end user may elect to print just a subset of the pages contained
        ///     in the document.  In this case, if page-range = n.m is specified, the
        ///     first page to be printed will be page n. All subsequent pages of the
        ///     document will be printed through and including page m.
        ///     "page-ranges-supported" is a boolean value indicating whether or not
        ///     the printer is capable of supporting the printing of page ranges.
        ///     This capability may differ from one PDL to another. There is no
        ///     "page-ranges-default" attribute.  If the "page-ranges" attribute is
        ///     not supplied by the client, all pages of the document will be
        ///     printed.
        /// </summary>
        public Range[]? PageRanges { get; set; }

        /// <summary>
        ///     This attribute specifies how print-stream pages are to be imposed
        ///     upon the sides of an instance of a selected medium, i.e., an
        ///     impression.
        /// </summary>
        public Sides? Sides { get; set; }

        /// <summary>
        ///     This attribute specifies the number of print-stream pages to impose
        ///     upon a single side of an instance of a selected medium.  For example,
        ///     if the value is:
        ///     '1'    the Printer MUST place one print-stream page on a single side
        ///     of an instance of the selected medium (MAY add some sort
        ///     of translation, scaling, or rotation).
        ///     '2'    the Printer MUST place two print-stream pages on a single side
        ///     of an instance of the selected medium (MAY add some sort
        ///     of translation, scaling, or rotation).
        ///     '4'    the Printer MUST place four print-stream pages on a single
        ///     side of an instance of the selected medium (MAY add some
        ///     sort of translation, scaling, or rotation).
        ///     This attribute primarily controls the translation, scaling and
        ///     rotation of print-stream pages.
        /// </summary>
        public int? NumberUp { get; set; }

        /// <summary>
        ///     This attribute indicates the desired orientation for printed print-
        ///     stream pages; it does not describe the orientation of the client-
        ///     supplied print-stream pages.
        ///     For some document formats (such as 'application/postscript'), the
        ///     desired orientation of the print-stream pages is specified within the
        ///     document data.  This information is generated by a device driver
        ///     prior to the submission of the print job.  Other document formats
        ///     (such as 'text/plain') do not include the notion of desired
        ///     orientation within the document data.  In the latter case it is
        ///     possible for the Printer object to bind the desired orientation to
        ///     the document data after it has been submitted.  It is expected that a
        ///     Printer object would only support "orientations-requested" for some
        ///     document formats (e.g., 'text/plain' or 'text/html') but not others
        ///     (e.g., 'application/postscript').  This is no different than any
        ///     other Job Template attribute since section 4.2, item 1, points out
        ///     that a Printer object may support or not support any Job Template
        ///     attribute based on the document format supplied by the client.
        ///     However, a special mention is made here since it is very likely that
        ///     a Printer object will support "orientation-requested" for only a
        ///     subset of the supported document formats.
        /// </summary>
        public Orientation? OrientationRequested { get; set; }

        /// <summary>
        ///     This attribute identifies the medium that the Printer uses for all
        ///     impressions of the Job.
        ///     The values for "media" include medium-names, medium-sizes, input-
        ///     trays and electronic forms so that one attribute specifies the media.
        ///     If a Printer object supports a medium name as a value of this
        ///     attribute, such a medium name implicitly selects an input-tray that
        ///     contains the specified medium.  If a Printer object supports a medium
        ///     size as a value of this attribute, such a medium size implicitly
        ///     selects a medium name that in turn implicitly selects an input-tray
        ///     that contains the medium with the specified size.  If a Printer
        ///     object supports an input-tray as the value of this attribute, such an
        ///     input-tray implicitly selects the medium that is in that input-tray
        ///     at the time the job prints.  This case includes manual-feed input-
        ///     trays.  If a Printer object supports an electronic form as the value
        ///     of this attribute, such an electronic form implicitly selects a
        ///     medium-name that in turn implicitly selects an input-tray that
        ///     contains the medium specified by the electronic form.  The electronic
        ///     form also implicitly selects an image that the Printer MUST merge
        ///     with the document data as its prints each page.
        /// </summary>
        public string? Media { get; set; }

        /// <summary>
        ///     This attribute identifies the resolution that Printer uses for the
        ///     Job.
        /// </summary>
        public Resolution? PrinterResolution { get; set; }

        /// <summary>
        ///     This attribute specifies the print quality that the Printer uses for
        ///     the Job.
        /// </summary>
        public PrintQuality? PrintQuality { get; set; }
        public PrintScaling? PrintScaling { get; set; }

        public IEnumerable<IppAttribute>? AdditionalOperationAttributes { get; set; }
        public IEnumerable<IppAttribute>? AdditionalJobAttributes { get; set; }
    }
}