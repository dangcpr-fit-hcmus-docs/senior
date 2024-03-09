def search(q):
    import elasticsearch
    es = elasticsearch.Elasticsearch("http://localhost:9200")
    query = {
        "query": {
            "bool": {
                "must": [
                    {"match": {"text": q}}
                ]
            }
        },
        "size": 10
    }

    result = es.search(body=query, index="demo", doc_type="paragraph")

    docs = []
    for doc in result["hits"]["hits"]:
        docs.append(
            {
                "title": doc["_source"]["title"],
                "text": doc["_source"]["text"]
            }
        )
    return docs


def classify(docs):
    import joblib
    text_clf, id2label = joblib.load('/Users/sonnguyen/vng/text-mining-tutorials/text_classification/models/trec6_model.pkl')

    predicted = text_clf.predict(docs)
    return [[doc, id2label[category]] for doc, category in zip(docs, predicted)]


if __name__ == '__main__':
    # docs = search("sông nào dài nhất thế giới")
    # for doc in docs:
    #     print(doc)

    docs_new = ['what is computer',
                'who is Newton',
                'when is the Tet holiday ?']
    # what is computer
    # who is Newton
    # when is the Tet holiday
    print(classify(docs_new))