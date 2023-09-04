import axios from "axios";
import * as cheerio from "cheerio";
import { Actor } from "apify";

await Actor.init();

const input = await Actor.getInput();
const { url } = input;

try {
    const response = await axios.get(url);
    const $ = cheerio.load(response.data);

    const NameOfURL = url;
    const TotalItems = $(".list-item-wrapper").length; // Count total items
    

    const extractedData = [];

    $(".list-item-wrapper").each((i, element) => {
        const Name = $(element).find(".list-item-heading").text().trim();
        const Annotation = $(element).find(".list-item-anotation").text().trim();
        const Content = $(element).find(".overlay-txt").text().trim();
        const Link = $(element).find(".overlay-link a").attr("href");
        const Image = $(element).find(".list-item-image").attr("data-src");

        const dataObject = {
            Name,
            Annotation,
            Content,
            Link,
            Image,
        };
        
        console.log("Extracted data", dataObject);
        extractedData.push(dataObject);
    });

    const result = {
        NameOfURL,
        TotalItems,
        Clients: extractedData,
    };

    await Actor.pushData(result);
} catch (error) {
    console.error("Error fetching or parsing data:", error);
}

await Actor.exit();